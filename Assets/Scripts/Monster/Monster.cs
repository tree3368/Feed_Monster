using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;
    [SerializeField] private float _timeDelay;
    [SerializeField] private int _damage;
    [SerializeField] private int _saturationFinal;

    private int _currentSaturation;
    private int _currentNumber;
    private float _elapsedTime;

    public event UnityAction<int> NumberChanged;
    public event UnityAction<int, int> SaturationChanged;
    public event UnityAction<Color> ColorChanged;

    public int Damage => _damage;
    public int CurrentSaturation => _currentSaturation;
    public int SaturationFinal => _saturationFinal;

    private void Start()
    {
        DetermineNumber();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _timeDelay)
        {
            DetermineNumber();
        }
    }

    public void DetermineNumber()
    {
        _elapsedTime = 0;
        _currentNumber = Random.Range(_minValue, _maxValue);
        NumberChanged?.Invoke(_currentNumber);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {
            if (ball.NumberOnBall == _currentNumber)
            {
                ColorChanged?.Invoke(Color.green);
                _currentSaturation++;
                SaturationChanged?.Invoke(_currentSaturation, _saturationFinal);
            }
            if (ball.NumberOnBall != _currentNumber)
            {
                ColorChanged?.Invoke(Color.red);
                _player.TakeDamage();           
            }
            _spawner.RemoveItem();
            Destroy(ball.gameObject);
            DetermineNumber();
        }
    }
}

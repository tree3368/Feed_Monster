using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;
    [SerializeField] private TMP_Text _counter;
    [SerializeField] private float _weight;
    
    private Spawner _spawner;
    private int _numberOnBall;

    public int NumberOnBall => _numberOnBall;
    public Player Player => _spawner.Player;
    public Transform Target => _spawner.Target;

    private void Awake()
    {
        _numberOnBall = Random.Range(_minValue, _maxValue);
        _counter.text = _numberOnBall.ToString();
        _spawner = GetComponentInParent<Spawner>();
    }

    public void DecreaseCounter()
    {
        _numberOnBall--;
        _counter.text = _numberOnBall.ToString();

        if (_numberOnBall <= 0)
        {
            Destroy(gameObject);
            _spawner.RemoveItem();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Ball[] _balls;
    [SerializeField] private Player _player;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _numberBalls;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private Transform _target;

    private Ball _currentBall;
    private float _currentTime;
    private List<Ball> _createdBalls = new List<Ball>();

    public Player Player => _player;
    public Transform Target => _target;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _timeBetweenSpawn && _createdBalls.Count < _numberBalls)
        {
            _currentTime = 0;
            _currentBall = _balls[Random.Range(0, _balls.Length)];
            _createdBalls.Add(_currentBall);
            Instantiate(_currentBall, _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity, transform);
        }
    }

    public void RemoveItem()
    {
        _createdBalls.RemoveAt(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Monster _monster;
    [SerializeField] private int _health;
    [SerializeField] private int _energe;
    [SerializeField] private int _energyCosts;

    private int _currentEnerge;
    private int _currentHealth;

    public event UnityAction<int, int> EnergeChanged;
    public event UnityAction<int, int> HealthChanged;

    public int CurrentEnerge => _currentEnerge;
    public int CurrentHealth => _currentHealth;
    public int EnergyCosts => _energyCosts;

    private void Start()
    {
        _currentEnerge = _energe;
        _currentHealth = _health;
    }

    public void ReduceEnergy()
    {
        _currentEnerge -= _energyCosts;
        EnergeChanged?.Invoke(_currentEnerge, _energe);
    }

    public void TakeDamage()
    {
        _currentHealth -= _monster.Damage;
        HealthChanged?.Invoke(_currentHealth, _health);
    }
}

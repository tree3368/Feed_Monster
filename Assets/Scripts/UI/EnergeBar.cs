using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergeBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.EnergeChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _player.EnergeChanged -= OnValueChanged;
    }
}

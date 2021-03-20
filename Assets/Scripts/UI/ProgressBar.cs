using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private Monster _monster;

    private void OnEnable()
    {
        _monster.SaturationChanged += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _monster.SaturationChanged -= OnValueChanged;
    }
}

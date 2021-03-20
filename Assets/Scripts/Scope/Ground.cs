using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Ground : MonoBehaviour
{
    [SerializeField] private Monster _monster;

    private SpriteRenderer _sprite;

    private void OnEnable()
    {
        _monster.ColorChanged += OnColorChanged;
    }

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnDisable()
    {
        _monster.ColorChanged -= OnColorChanged;
    }

    public void OnColorChanged(Color targetColor)
    {
        _sprite.color = targetColor;
    }
}

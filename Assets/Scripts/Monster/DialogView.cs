using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogView : MonoBehaviour
{
    [SerializeField] private TMP_Text _numberText;
    [SerializeField] private Monster _monster;

    private void OnEnable()
    {
        _monster.NumberChanged += OnNumberChanged;
    }

    private void OnDisable()
    {
        _monster.NumberChanged -= OnNumberChanged;
    }

    private void OnNumberChanged(int currentNumber)
    {
        _numberText.text = currentNumber.ToString();
    }
}

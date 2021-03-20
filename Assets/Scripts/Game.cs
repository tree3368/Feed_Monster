using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private const string _sceneGame = "Game";
    private const string _nextScene = "Game1";

    [SerializeField] private Player _player;
    [SerializeField] private Monster _monster;
    [SerializeField] private GameObject _lossPanel;
    [SerializeField] private GameObject _finalPanel;
    [SerializeField] private Spawner _spawner;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (_player.CurrentHealth < _monster.Damage)
            OpenPanel(_lossPanel);
        if (_monster.CurrentSaturation >= _monster.SaturationFinal)
            OpenPanel(_finalPanel);
    }

    private void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(_sceneGame);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(_nextScene);
    }
}

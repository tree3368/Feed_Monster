using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StratGame : MonoBehaviour
{
    private const string _starScene = "Game";

    public void LaunchScene()
    {
        SceneManager.LoadScene(_starScene);
    }
}

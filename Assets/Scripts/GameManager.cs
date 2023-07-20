using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelGameOver;

    void Awake()
    {
        Time.timeScale = 1.0f;
        panelGameOver.SetActive(false);
    }

    public void RestarGame(){
        SceneManager.LoadScene(0);
    }

    public void PlayerDied(){
        Time.timeScale = 0f;
        panelGameOver.SetActive(true);
    }
}
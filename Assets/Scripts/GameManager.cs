using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Game Over Panel Variables
    public GameObject panelGameOver;    
    [SerializeField] GameObject _cherry;
    
    // Score Variables
    [SerializeField] TextMeshProUGUI _txtScore;
    DotCollect _dotCollect;
    
    private void Awake()
    {
        Time.timeScale = 1.0f;
        panelGameOver.SetActive(false);
        _cherry.SetActive(false);
    }

    private void Start() {
        _dotCollect = FindObjectOfType<DotCollect>();        
    }

    private void Update() {
        _txtScore.text = "" + _dotCollect.Sc;
        CherryActivation();
    }

    public void RestarGame(){
        SceneManager.LoadScene(0);
    }

    public void PlayerDied(){
        Time.timeScale = 0f;
        panelGameOver.SetActive(true);
    }

    void CherryActivation(){
        if (_dotCollect.Sc == 15)
        {
            _cherry.SetActive(true);
        }
    }
}
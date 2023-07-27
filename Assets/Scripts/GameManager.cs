using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public static GameManager instance;

    // Game Over Panel Variables
    public GameObject panelGameOver;    
    [SerializeField] GameObject cherry;
    
    // Score Variables
    [SerializeField] TextMeshProUGUI _txtScore;
    DotCollect _dotCollect;
    
    private void Awake()
    {
        // if (GameManager.instance == null){
        //     GameManager.instance = this;
        //     DontDestroyOnLoad(gameObject);
        // }
        // else {
        //     Destroy(gameObject);
        // }   

        Time.timeScale = 1.0f;
        panelGameOver.SetActive(false);
        cherry.SetActive(false);
    }

    private void Start() {
        _dotCollect = FindObjectOfType<DotCollect>();        
    }

    private void Update() {
        _txtScore.text = "" + _dotCollect.ScoreDots;
        CherryActivation();
    }

    public void RestarGame(){
        SceneManager.LoadScene(0);
    }

    public void PlayerDied(){
        Time.timeScale = 0f;
        panelGameOver.SetActive(true);
    }

    public void CherryActivation(){
        if (_dotCollect.ScoreDots == 15)
        {
            cherry.SetActive(true);
        }

        if (_dotCollect.fruitCollected)
        {
            cherry.SetActive(false);
        }
    }
    
}
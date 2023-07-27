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

    [SerializeField] GameObject _player;
    [SerializeField] GameObject cherry;
    
    // Score Variables
    [SerializeField] TextMeshProUGUI _txtScore;
    PointsCollect _pointsCollect;

    // Music AudioSource
    [SerializeField] AudioSource _musicGame;
    
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
        _pointsCollect = FindObjectOfType<PointsCollect>();        
    }

    private void Update() {
        _txtScore.text = "" + _pointsCollect.ScoreDots;
        CherryActivation();
    }

    public void RestarGame(){
        SceneManager.LoadScene(0);
    }

    // public void PlayerDied(){
    //     Time.timeScale = 0f;
    //     panelGameOver.SetActive(true);
    //     _musicGame.Stop();        
    //     AudioManager.intance.PlaySfx(3);        
    // }

    public void CherryActivation(){
        if (_pointsCollect.ScoreDots == 150)
        {
            cherry.SetActive(true);
        }

        if (_pointsCollect.fruitCollected)
        {
            cherry.SetActive(false);
        }
    }

    public IEnumerator PlayerDiedRutine(){
        _player.GetComponent<Move>().enabled = false;
        _player.GetComponentInChildren<Animator>().SetTrigger("IsDead");
        yield return new WaitForSeconds(1);
        _musicGame.Stop();        
        AudioManager.intance.PlaySfx(3); 
        yield return new WaitForSeconds(3);
        Time.timeScale = 0f;
        panelGameOver.SetActive(true);          
        yield return null;
    }
    
}
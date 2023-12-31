using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Game Over Panel Variables
    public GameObject panelWin;    
    public GameObject panelGameOver;    
    [SerializeField] GameObject _panelScore;

    [SerializeField] GameObject _player;
    [SerializeField] GameObject cherry;
    bool _cherry;
    bool _win;
    
    // Score Variables
    [SerializeField] TextMeshProUGUI _txtScore;
    PointsCollect _pointsCollect;

    // Music AudioSource
    [SerializeField] AudioSource _sfxBackground;
    [SerializeField] AudioSource _musicGame;

    //Ghosts script
    public MovePhantom phantom;

    
    private void Awake()
    {
        Time.timeScale = 1.0f;
        panelGameOver.SetActive(false);
        panelWin.SetActive(false);
        cherry.SetActive(false);
    }

    private void Start() {
        //_musicGame = FindObjectOfType<AudioSource>();
        _pointsCollect = FindObjectOfType<PointsCollect>();        
        _panelScore.SetActive(true);
        _cherry = false;     
         _win = false;  
    }

    private void Update() {
        _txtScore.text = "" + _pointsCollect.ScoreDots;
        CherryActivation();
        Debug.Log(_pointsCollect.dotCounter);
        Win();
    }

    public void CherryActivation(){
        if (_pointsCollect.ScoreDots == 150)
            cherry.SetActive(true);
        
        if (!_cherry && _pointsCollect.ScoreDots == 150){
            _cherry = true;
            AudioManager.intance.PlaySfx(5);
            }
        if (_pointsCollect.fruitCollected)
            cherry.SetActive(false);
    }

    public void Win(){
        if (!_win && _pointsCollect.dotCounter == 99)
        {
            _win = true;
            Time.timeScale = 0f;  
            AudioManager.intance.PlaySfx(9);
            _player.GetComponent<Move>().enabled = false;
            _panelScore.SetActive(false);
            panelWin.SetActive(true);    
            _musicGame.GetComponent<AudioSource>().Stop();
            _sfxBackground.GetComponent<AudioSource>().Stop();                        
        }        
    }
    
    public IEnumerator PlayerDiedRutine(){
        AudioManager.intance.PlaySfx(6);
        _player.GetComponent<Move>().enabled = false;
        _player.GetComponent<PlayerDeath>().enabled = false;
        _player.GetComponentInChildren<Animator>().SetTrigger("IsDead");
        yield return new WaitForSeconds(1);
        _sfxBackground.GetComponent<AudioSource>().Stop();
        //AudioManager.intance.PlaySfx(3); 
        AudioManager.intance.PlaySfx(8);
        yield return new WaitForSeconds(3);
        Time.timeScale = 0f;  
        panelGameOver.SetActive(true);     
        _panelScore.SetActive(false);
        yield return null;
    }

    public void PlayAgain(){
        AudioManager.intance.StopSfx(8);
        AudioManager.intance.PlaySfx(7);
        GameObject.Find("Fade").GetComponent<Animator>().Play("FadeOut");
        SceneManager.LoadScene(1);
    }

    public void QuiteGame(){
        AudioManager.intance.PlaySfx(7);
        Application.Quit();
    }    
}
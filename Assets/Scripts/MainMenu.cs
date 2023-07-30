using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayGame(){
        AudioManager.intance.PlaySfx(7);
        StartCoroutine(SceneController.Instance.ChangeScene(1, 2f));        
    }

    public void QuiteGame(){
        AudioManager.intance.PlaySfx(7);
        Application.Quit();
    }
}
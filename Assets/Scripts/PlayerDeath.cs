using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start() {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // bool _playerIsAlive = true;
    // public bool PL {get => _playerIsAlive; set => _playerIsAlive = value;}

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Phantom")){
            Debug.Log("you loose");
            _gameManager.PlayerDied();
        }
    }
}
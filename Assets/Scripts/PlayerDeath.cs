using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private GameManager _gameManager;
    
    private void Start() {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Phantom")){
            StartCoroutine(_gameManager.PlayerDiedRutine());            
        }        
    }
}
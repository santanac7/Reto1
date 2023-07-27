using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCollect : MonoBehaviour
{    
    [SerializeField] GameManager _gameManager;
    private int _points;
    private bool _cherryCollect = false;

    public int ScoreDots {get => _points; set => _points = value;}
    public bool fruitCollected {get => _cherryCollect; set => _cherryCollect = value;}
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Dot")){
            other.gameObject.SetActive(false);
            _points += 10;       
            AudioManager.intance.PlaySfx(0);
        }       

        if (other.CompareTag("Fruit"))
        {
            //_cherryCollect = true;
            AudioManager.intance.PlaySfx(2);
            _points += 400;
            _cherryCollect = true;
        }
    }   
}
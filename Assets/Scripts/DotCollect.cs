using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotCollect : MonoBehaviour
{    
    private int points;
    public int Sc {get => points; set => points = value;}
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Dot")){
            other.gameObject.SetActive(false);
            points ++;            
        }
    }
}
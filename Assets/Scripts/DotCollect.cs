using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Dot")){
            Debug.Log("Catch Dot");
            Destroy(other.gameObject);
        }
    }
}
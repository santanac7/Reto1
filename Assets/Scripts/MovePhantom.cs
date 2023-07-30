using UnityEngine;
using System.Collections;

public class MovePhantom : MonoBehaviour
{
    [SerializeField] Vector3[] _targetPositions;
    [SerializeField] int[] _rotations;
    //[SerializeField] float _rotation;
    public GameObject _phantom;

    private void Start() {
        StartCoroutine(PhantomTargets());
        //_phantom = GameObject.FindGameObjectWithTag("Phantom");
    }

    IEnumerator PhantomTargets(){
    
        while (true)
        {
            for (int i = 0; i < _targetPositions.Length; i++){
                Vector3 _nextTarget = _targetPositions[i];
                float _duration = 1.0f;
                float _elapsedTime = 0.0f;
                Vector3 _startPosition = _phantom.transform.position;
                
                // Vector3 _currentRotation = _phantom.transform.rotation.eulerAngles;
                // _currentRotation.y -= _rotation;
                // _phantom.transform.rotation = Quaternion.Euler(_currentRotation);
                
                while (_elapsedTime < _duration)
                {
                    _elapsedTime += Time.deltaTime;
                    float _t = Mathf.Clamp01(_elapsedTime / _duration);
                    _phantom.transform.position = Vector3.Lerp(_startPosition, _nextTarget, _t);
                    yield return null;
                }
            }           
        }                
    }
}
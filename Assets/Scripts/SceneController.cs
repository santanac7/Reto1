using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    public IEnumerator ChangeScene(int sceneIndex, float timeOut){
        yield return new WaitForSeconds(1);
        GameObject.Find("Fade").GetComponent<Animator>().Play("FadeOut");
        yield return new WaitForSeconds(timeOut);
        SceneManager.LoadScene(sceneIndex);
        Debug.Log("Play Again");
    }
}
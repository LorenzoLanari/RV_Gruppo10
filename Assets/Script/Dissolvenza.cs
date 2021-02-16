using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dissolvenza : MonoBehaviour
{
    public Animator  DissolvenzaAnimator;
    public float transitionTime = 1f;

    public void Play()
    {
        DissolvenzaAnimator.SetTrigger("start");
    }
    public void ReloadLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadNextLevel()
    {
       StartCoroutine( LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //DissolvenzaAnimator.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

   
}

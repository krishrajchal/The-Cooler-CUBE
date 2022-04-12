using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class NextLevel : MonoBehaviour
{
    public string nextLevel;
    public int neededScore;
    public Stars stars;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (stars.score == neededScore)
            {
                StartCoroutine(wait2SecondsBeforeChangingScene()); 
            }
        }
    }

    IEnumerator wait2SecondsBeforeChangingScene()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        SceneManager.LoadScene(nextLevel);
    }
}

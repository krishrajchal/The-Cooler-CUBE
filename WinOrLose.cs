using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinOrLose : MonoBehaviour
{
    public Health BossHealth;
    public Health PlayerHealth;

    public GameObject PlayerWin;
    public GameObject BossWin;

    // Update is called once per frame
    void Update()
    {
        if (BossHealth.hp == 0)
        {
            PlayerWin.SetActive(true);
        }
        else if (PlayerHealth.hp == 0) { 
            BossWin.SetActive(true);
        }
    }

    public void exit() { 
        Application.Quit();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

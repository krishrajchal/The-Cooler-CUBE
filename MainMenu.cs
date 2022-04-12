using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Sensitivity"))
        {
            PlayerPrefs.SetInt("Sensitivity", 250);
        }

        if (!PlayerPrefs.HasKey("FOV"))
        {
            PlayerPrefs.SetInt("FOV", 60);
        }
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void start()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LS()
    {
        SceneManager.LoadScene("LS");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
}

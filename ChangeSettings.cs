using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeSettings : MonoBehaviour
{
    public Slider fovSlider;
    public Slider sensSlider;

    public TextMeshProUGUI fovText;
    public TextMeshProUGUI sensText;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Sensitivity"))
        {
            PlayerPrefs.SetInt("Sensitivity", 250);
        }

        if (!PlayerPrefs.HasKey("FOV"))
        {
            PlayerPrefs.SetInt("FOV", 60);
        }
        fovSlider.value = PlayerPrefs.GetInt("FOV");
        sensSlider.value = PlayerPrefs.GetInt("Sensitivity");
        fovText.text = PlayerPrefs.GetInt("FOV").ToString();
        sensText.text = PlayerPrefs.GetInt("Sensitivity").ToString();
    }
    public void fov()
    {
        PlayerPrefs.SetInt("FOV", (int)fovSlider.value);
        fovText.text = fovSlider.value.ToString();
    }

    public void sensitivity()
    {
        PlayerPrefs.SetInt("Sensitivity", int.Parse(sensSlider.value.ToString()));
        sensText.text = sensSlider.value.ToString();
    }
}

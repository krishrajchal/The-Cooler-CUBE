using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform pIayer;
    public Player player;

    private float xRotation = 0f;

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
        mouseSensitivity = PlayerPrefs.GetInt("Sensitivity");
        GetComponent<Camera>().fieldOfView = PlayerPrefs.GetInt("FOV");
    }

    void Update()
    {
        if (player.ded)
            return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        pIayer.Rotate(Vector3.up * mouseX);
    }
}

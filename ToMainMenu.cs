using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    public string keyToGoToMenu = "p";

    private void Update()
    {
        if (Input.GetKey(keyToGoToMenu))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

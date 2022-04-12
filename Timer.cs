using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Player player;

    float t;

    // Update is called once per frame
    void Update()
    {
        if (player.ded)
            return;

        t += Time.deltaTime;
        text.text = "Time: " + string.Format("{0:0}:{1:00}:{2:00}", Mathf.FloorToInt(t / 60), Mathf.FloorToInt(t - Mathf.FloorToInt(t / 60) * 60), t * 100 % 100);
    }
}

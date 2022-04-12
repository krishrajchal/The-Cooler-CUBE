using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public NextLevel nextLevel;
    public Stars stars;

    private void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Diamonds left to collect: " + (nextLevel.neededScore - stars.score).ToString();
    }
}

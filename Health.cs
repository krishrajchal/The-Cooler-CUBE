using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float hp;

    void Update()
    {
        gameObject.GetComponent<Image>().fillAmount = hp / 100;
    }
}

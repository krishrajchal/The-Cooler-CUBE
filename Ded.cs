using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ded : MonoBehaviour
{
    public TMP_Text text;
    public Collider player;
    public Player pIayer;

    public Collider[] colliders;

    float t;

    // Start is called before the first frame update
    void Start()
    {
        text.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        if (DumbWaysToDie())
        {
            pIayer.ded = true;
            text.color = Color.white;
        }
        if (pIayer.ded)
        {
            t += Time.deltaTime;
            if(t >= 2)
            {
                t = 0;
                pIayer.ded = false;
                text.color = Color.clear;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    bool DumbWaysToDie()
    {
        foreach(Collider collider in colliders)
        {
            if (collider.bounds.Intersects(player.bounds))
            {
                return true;
            }
        }
        return false;
    }
}

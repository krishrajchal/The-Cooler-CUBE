using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public Collider[] diamonds;
    public Collider player;

    public int score = 0;
    // Update is called once per frame
    void Update()
    {
        foreach (Collider diamond in diamonds)
        {
            if(diamond == null)
            {
                continue;
            }
            if(diamond.bounds.Intersects(player.bounds)){
                score++;
                Destroy(diamond.gameObject);
                diamonds[System.Array.IndexOf(diamonds, diamond)] = null;
            }
        }
    }
}

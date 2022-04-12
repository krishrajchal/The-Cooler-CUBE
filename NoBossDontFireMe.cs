using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBossDontFireMe : MonoBehaviour
{
    public Collider Cone;
    public GameObject GunSet1;
    public GameObject GunSet2;
    public GameObject MainGunSet;

    public GameObject[] GunShooters1;
    public GameObject[] GunShooters2;
    public GameObject Bullet;
    public float PunchesPerSecond;
    public float damping = 10;

    public Player player;
    public Health playerHealth;
    public Health bossHealth;

    public bool active;
    float t;
    float conePoisoningRefresh;
    Vector3 offset;

    void Start()
    {
        player.ded = false;
        offset = new Vector3(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!active || playerHealth.hp == 0 || bossHealth.hp == 0)
        {
            return;
        }

        if (Cone.bounds.Intersects(player.gameObject.GetComponent<Collider>().bounds) && conePoisoningRefresh >= 1)
        {
            playerHealth.hp -= 10;
            conePoisoningRefresh = 0;
        }

        var lookPos = player.transform.position - MainGunSet.transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        MainGunSet.transform.rotation = Quaternion.Slerp(MainGunSet.transform.rotation, rotation, Time.deltaTime * damping);

        GunSet1.transform.LookAt(player.transform.position);
        GunSet2.transform.LookAt(player.transform.position);

        GunSet1.transform.rotation *= Quaternion.Euler(offset);
        GunSet2.transform.rotation *= Quaternion.Euler(offset);

        conePoisoningRefresh += Time.deltaTime;
        if (t <= PunchesPerSecond)
        {
            t += Time.deltaTime;
            return;
        }

        t = 0;

        for(int i = 0; i < GunShooters1.Length; i++)
        {
            GameObject b1 = Instantiate(Bullet);
            b1.transform.position = GunShooters1[i].gameObject.transform.position;
            b1.transform.localScale = new Vector3(0.2568482f, 0.2568482f, 0.2568482f);
            b1.transform.rotation = GunShooters1[i].transform.rotation;
            b1.GetComponent<LaunchBullets>().copy = true;

            GameObject b2 = Instantiate(Bullet);
            b2.transform.position = GunShooters2[i].gameObject.transform.position;
            b2.transform.localScale = new Vector3(0.2568482f, 0.2568482f, 0.2568482f);
            b2.transform.rotation = GunShooters1[i].transform.rotation;
            b2.GetComponent<LaunchBullets>().copy = true;
        }
    }
}
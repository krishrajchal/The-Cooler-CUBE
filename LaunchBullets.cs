using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBullets : MonoBehaviour
{
    public Player player;
    public Health health;
    public Health bossHealth;
    public Collider boss;

    public float BulletDamage;
    public float BulletSpeed;
    public bool copy = false;

    void Update()
    {
        if (!copy)
        {
            return;
        }
        if (boss.bounds.Intersects(player.GetComponent<Collider>().bounds))
        {
            bossHealth.hp -= BulletDamage;
        }
        transform.LookAt(player.transform);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, BulletSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, player.transform.position) >= 100)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!copy)
        {
            return;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            health.hp -= BulletDamage;
        }
        Destroy(gameObject);
    }
}

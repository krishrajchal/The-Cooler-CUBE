using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEventOnCollision : MonoBehaviour
{
    public Animation anim;
    public Camera cam;
    public NoBossDontFireMe fireMe; // VS automaticly named this var
    public Player player;
    public float speed = 10f;

    bool active = false;
    bool playing = false;
    bool playAnimation = false;

    void Update()
    {

        if (playAnimation)
        {
            if (!playing)
            {
                anim.Play();
                playing = true;
            }
            if (!anim.IsPlaying("BOSS"))
            {
                player.ded = false;
                fireMe.active = true;
                active = false;
                playAnimation = false;
                Destroy(this);
            }
        }
        if (cam.transform.rotation == Quaternion.identity && player.transform.localPosition == new Vector3(2.71f, 9.09f, -60.44f) && player.transform.rotation == Quaternion.identity)
        {
            playAnimation = true;
        }

        if (active && !playing && !(cam.transform.rotation == Quaternion.identity && player.transform.localPosition == new Vector3(2.71f, 9.09f, -60.44f) && player.transform.rotation == Quaternion.identity)) {
            player.transform.localPosition = Vector3.MoveTowards(player.transform.localPosition, new Vector3(2.71f, 9.09f, -60.44f), speed);
            cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, Quaternion.identity, speed);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.identity, speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.ded = true;
            active = true;
        }
    }
}

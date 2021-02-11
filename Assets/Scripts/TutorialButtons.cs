using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtons : MonoBehaviour
{
    public int currentClip = 1;
    public AudioClip part1;
    public AudioClip part2;
    public AudioClip part3;
    public AudioClip part4;
    public AudioClip part5;
    public float hitVol = 5f;
    public AudioSource source;
    public float talkTime = 0;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        currentTime = talkTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "player1")
        {
            if (currentClip == 1)
            {
                if (currentTime <= 0)
                {
                    source.PlayOneShot(part1, hitVol);
                    currentTime = talkTime;
                }
            }
            if (currentClip == 2)
            {
                if (currentTime <= 0)
                {
                    source.PlayOneShot(part2, hitVol);
                    currentTime = talkTime;
                }
            }
            if (currentClip == 3)
            {
                if (currentTime <= 0)
                {
                    source.PlayOneShot(part3, hitVol);
                    currentTime = talkTime;
                }
            }
            if (currentClip == 4)
            {
                if (currentTime <= 0)
                {
                    source.PlayOneShot(part4, hitVol);
                    currentTime = talkTime;
                }
            }
            if (currentClip == 5)
            {
                if (currentTime <= 0)
                {
                    source.PlayOneShot(part5, hitVol);
                    currentTime = talkTime;
                }
            }

        }
    }
}

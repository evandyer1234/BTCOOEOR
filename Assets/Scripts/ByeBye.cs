using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByeBye : MonoBehaviour
{
    public GameObject platform;
    public GameObject music;
    public GameObject Boss;
    public GameObject slider;
    public GameObject text;
    public AudioSource source;
    public AudioClip Welcome;
    public float hitVol = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.tag == "player1" || other.transform.parent.tag == "player2" || other.transform.parent.tag == "player3" || other.transform.parent.tag == "player4")
        {
            source.PlayOneShot(Welcome, hitVol);
            platform.SetActive(false);
            music.SetActive(true);
            Boss.SetActive(true);
            slider.SetActive(true);
            text.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

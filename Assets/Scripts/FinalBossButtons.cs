using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossButtons : MonoBehaviour
{
    public GameObject door;
    public GameObject generator;
    public GameObject energy;
    public GameObject platform;
    public GameObject NextPhase;
    public GameObject NextCamera;
    public GameObject text;
    public bool isLast = false;
    bool exploding = false;
    public Explosive explosive;
    public float explosiveTime;
    public float MinX = -170.0f;
    public float MaxX = -106.0f;
    public float MinY = -155.0f;
    public float MaxY = -97.0f;
    public float MaxZ = -148.0f;
    public float MinZ = -211.0f;
    public float hitVol = 5f;
    public AudioSource source;
    public AudioClip stop;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (exploding)
        {
            explosiveTime -= Time.deltaTime;
            Vector3 position = new Vector3(Random.Range(MaxX, MinX), Random.Range(MaxY, MinY), Random.Range(MaxZ, MinZ));
            Explosive clone = (Explosive)Instantiate(explosive, position, Quaternion.identity);
            clone.clone = true;
        }
        if (explosiveTime <= 0)
        {
           
            generator.SetActive(false);
            exploding = false;
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "player1" || collision.transform.tag == "player2" || collision.transform.tag == "player3" || collision.transform.tag == "player4")
        {
            source.PlayOneShot(stop, hitVol);
            if (isLast != true)
            {
                NextPhase.SetActive(true);
            }
            energy.SetActive(false);
            NextCamera.SetActive(true);
            platform.SetActive(true);
            door.SetActive(true);
            if (isLast == true)
            {
               
                text.SetActive(true);
            }
            exploding = true;
        }
    }
}

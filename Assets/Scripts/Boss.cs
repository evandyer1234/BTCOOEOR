using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int startingHealth = 20;
    int bosshealth = 1;
   
    public Attack1 Arm;
    public GameObject music;
    public GameObject voice;
    public GameObject below;
    public GameObject hold;
    public GameObject Shooter;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject spawns;
    public GameObject Destination;
    public GameObject Self;
    public float startTimer = 60;
    float timer = 60;
    public float deadtime = 1;
    bool dead = false;
    bool attack1 = false;
    bool attack3set = false;
    
    bool endCalled = false;
    bool boomed = false;
    bool boomed2 = false;
    bool deadPlayed = false;
    public Explosive boom;
    public Attack3 attack3;
    public GameObject SpawnLocation;
    public Slider healthSlider;
    public Bombs bomb;
    public Explosive explosive;
    public float Attack1time = 40f;
    public float Attack2time = 20f;
    public float Attack2active = 10f;
    public float Attack3active = 5f;
    bool attack2Done = false;
    public float MaxX = 0;
    public float MinX = 0;
    public float MaxY = 0;
    public float MinY = 0;
    public float MinZ = 0;
    public float MaxZ = 0;
    public float hitVol = 5f;
    public AudioSource source;
    public AudioClip blaster;
    public AudioClip bombs;
    public AudioClip getoff;
    public AudioClip friend;
    public AudioClip tplayer1;
    public AudioClip tplayer2;
    public AudioClip tplayer3;
    public AudioClip tplayer4;
    public AudioClip defeat;

    int rPlayer = 0;


    // Start is called before the first frame update
    void Start()
    {
        timer = startTimer;
        bosshealth = startingHealth;
        healthSlider.maxValue = startingHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        healthSlider.value = bosshealth;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = startTimer;
            attack3set = false;
            attack1 = false;
            attack2Done = false;
        }
        
        if (attack1 == false && timer <= Attack1time)
        {
            attack1 = true;
            Attack1();
        }
        if (timer <= Attack2time && timer >= Attack2time - Attack2active)
        {
            Attack2();
        }
        if (timer <= 5 && attack3set == false)
        {
            Attack3();
        }
        if (dead)
        {
            if (deadPlayed == false)
            {
                source.PlayOneShot(defeat, hitVol);
                deadPlayed = true;
            }
            exploding();
            deadtime -= Time.deltaTime;
        }
        if (deadtime <= 0 && endCalled == false)
        {
            End();
        }
        if (bosshealth <= 0)
        {
            dead = true;
        }
        if (bosshealth <= startingHealth / 2 && boomed == false)
        {
            source.PlayOneShot(getoff, hitVol);
            Explosive clone = (Explosive)Instantiate(boom, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
            clone.clone = true;
            boomed = true;
        }
        if (bosshealth <= startingHealth / 4 && boomed2 == false)
        {
            source.PlayOneShot(getoff, hitVol);
            Explosive clone = (Explosive)Instantiate(boom, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
            clone.clone = true;
            boomed2 = true;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Fist")
        {
            this.bosshealth--;
        }
        if (collision.transform.tag == "pboom")
        {
            this.bosshealth = bosshealth - 100;
            source.PlayOneShot(friend, hitVol);
        }
    }
    void Attack1()
    {
        source.PlayOneShot(blaster, hitVol);
        Attack1 clone = (Attack1)Instantiate(Arm, below.transform.position, below.transform.rotation);
        clone.clone = true;
    }
    void Attack2()
    {
        if (attack2Done == false)
        {
            source.PlayOneShot(bombs, hitVol);
            attack2Done = true;
        }
        Vector3 position = new Vector3(Random.Range(-160.0f, 230.0f), -40.5f, Random.Range(-433.0f, -87.0f));
        Bombs clone = (Bombs)Instantiate(bomb, position, Quaternion.identity);
    }
    void Attack3()
    {
        rPlayer = Random.Range(1, 5);

        if (rPlayer == 1)
        {
            source.PlayOneShot(tplayer1, hitVol);
            hold.transform.position = new Vector3(74.3f, player1.transform.position.y, -127.3f);
        }
        if (rPlayer == 2)
        {
            source.PlayOneShot(tplayer2, hitVol);
            hold.transform.position = new Vector3(74.3f, player2.transform.position.y, -127.3f);
        }
        if (rPlayer == 3)
        {
            source.PlayOneShot(tplayer3, hitVol);
            hold.transform.position = new Vector3(74.3f, player3.transform.position.y, -127.3f);
        }
        if (rPlayer == 4)
        {
            source.PlayOneShot(tplayer4, hitVol);
            hold.transform.position = new Vector3(74.3f, player4.transform.position.y, -127.3f);
        }
        Attack3 clone = (Attack3)Instantiate(attack3, hold.transform.position, hold.transform.rotation);
        clone.clone = true;
        attack3set = true;
    }
    
    void exploding()
    {
        Vector3 position = new Vector3(Random.Range(MaxX, MinX), Random.Range(MaxY, MinY), Random.Range(MaxZ, MinZ));
        Explosive clone = (Explosive)Instantiate(explosive, position, Quaternion.identity);
        clone.clone = true;
    }
    
    void End()
    {
        endCalled = true;
        music.SetActive(false);
        voice.SetActive(false);
        Self.SetActive(false);

        player1.transform.position = point1.transform.position;
        player1.transform.rotation = point1.transform.rotation;

        player2.transform.position = point2.transform.position;
        player2.transform.rotation = point2.transform.rotation;

        player3.transform.position = point3.transform.position;
        player3.transform.rotation = point3.transform.rotation;

        player4.transform.position = point4.transform.position;
        player4.transform.rotation = point4.transform.rotation;

        spawns.transform.position = Destination.transform.position;
    }
}

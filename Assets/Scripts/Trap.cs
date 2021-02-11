using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject point;
    public Bashed basher;
    public float CountDown = 1;
    public float Count = 0;
    bool isIn = false;
    
   
    // Start is called before the first frame update
    void Start()
    {
        Count = CountDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIn)
        {
            Count -= Time.deltaTime;
        }
        if (Count <= 0)
        {
            Bashed clone = (Bashed)Instantiate(basher, point.transform.position, point.transform.rotation);
            clone.clone = true;
            Count = CountDown;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Boom" || collision.transform.tag != "Fist" || collision.transform.tag != "KillZone")
        {
            isIn = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        isIn = false;
    }



}

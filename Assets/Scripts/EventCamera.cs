using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCamera : MonoBehaviour
{
    public float time = 2f;
    public GameObject circle;
    public GameObject p1c;
    public GameObject p2c;
    public GameObject p3c;
    public GameObject p4c;
    public bool isLast = false;
    // Start is called before the first frame update
    void Start()
    {
        

    }
    void Awake()
    {/*
        p1c.SetActive(false);
        p2c.SetActive(false);
        p3c.SetActive(false);
        p4c.SetActive(false);
        */
        if (isLast)
        {
            circle.SetActive(true);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            p1c.SetActive(true);
            p2c.SetActive(true);
            p3c.SetActive(true);
            p4c.SetActive(true);
            gameObject.SetActive(false);
            if (isLast)
            {
                circle.SetActive(false);
               
            }
        }
    }
}

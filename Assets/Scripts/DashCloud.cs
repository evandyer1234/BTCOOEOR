using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCloud : MonoBehaviour
{
    public GameObject particle;
    
    public bool p1 = false;
    public bool p2 = false;
    public bool p3 = false;
    public bool p4 = false;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p1)
        {
            particle.transform.position = player1.transform.position;
            particle.transform.rotation = player1.transform.rotation;
        }
        if (p2)
        {
            particle.transform.position = player2.transform.position;
            particle.transform.rotation = player2.transform.rotation;
        }
        if (p3)
        {
            particle.transform.position = player3.transform.position;
            particle.transform.rotation = player3.transform.rotation;
        }
        if (p4)
        {
            particle.transform.position = player4.transform.position;
            particle.transform.rotation = player4.transform.rotation;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject other;
    public bool turnOn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "player1" || collision.transform.tag == "player2" || collision.transform.tag == "player3" || collision.transform.tag == "player4")
        {
            if (turnOn == false)
            {
                other.SetActive(false);
            }
            else
            {
                other.SetActive(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boostpad : MonoBehaviour
{
    public float punchForce = 10;
    public float upForce = 10;
    public float direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "player1" || other.transform.tag == "player2" || other.transform.tag == "player3" || other.transform.tag == "player4")
        {
            other.collider.attachedRigidbody.velocity = new Vector3(0, 0, 0);
            other.collider.attachedRigidbody.AddForce(transform.forward * punchForce * direction);
            other.collider.attachedRigidbody.AddForce(transform.up * punchForce);
        }
    }
}

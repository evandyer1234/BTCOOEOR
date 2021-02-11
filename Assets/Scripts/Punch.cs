using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public bool clone = false;
    public float time = 11;
    public float punchForce = 10;
    public float upForce = 10;
    public bool isPlayer1 = false;
    public bool isPlayer2 = false;
    public bool isPlayer3 = false;
    public bool isPlayer4 = false;
    float elseCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clone)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    public void OnCollisionEnter(Collision other)
    {
        if (isPlayer1)
        {
            if (other.transform.tag != "player1")
            {
                other.collider.attachedRigidbody.AddForce(transform.forward * punchForce);
                other.collider.attachedRigidbody.AddForce(transform.up * punchForce);
            }
            else
            {
                elseCount++;
            }
        }
        if (isPlayer2)
        {
            if (other.transform.tag != "player2")
            {
                other.collider.attachedRigidbody.AddForce(transform.forward * punchForce);
                other.collider.attachedRigidbody.AddForce(transform.up * punchForce);
            }
            else
            {
                elseCount++;
            }
        }
        if (isPlayer3)
        {
            if (other.transform.tag != "player3")
            {
                other.collider.attachedRigidbody.AddForce(transform.forward * punchForce);
                other.collider.attachedRigidbody.AddForce(transform.up * punchForce);
            }
            else
            {
                elseCount++;
            }
        }
        if (isPlayer4)
        {
            if (other.transform.tag != "player4")
            {
                other.collider.attachedRigidbody.AddForce(transform.forward * punchForce);
                other.collider.attachedRigidbody.AddForce(transform.up * punchForce);
            }
            else
            {
                elseCount++;
            }
        }
       
    }
    

}

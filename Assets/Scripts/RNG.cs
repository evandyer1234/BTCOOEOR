using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNG : MonoBehaviour
{
    
    public float speed = 10;
    public bool clone = false;
    public float time = 11;
    public float pushForce = 10;
    Rigidbody rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (clone)
        {
            
            Vector3 location = rb.position;

            location += (speed * Time.fixedDeltaTime * transform.forward);


            rb.position = location;
        }
        if (time <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        collision.collider.attachedRigidbody.AddForce(transform.forward * pushForce);
    }
}

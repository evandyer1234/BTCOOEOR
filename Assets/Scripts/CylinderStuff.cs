using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderStuff : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Fist" || collision.transform.tag == "Boom")
        {
            m_Rigidbody.constraints = RigidbodyConstraints.None;
        }
        if (collision.transform.tag == "KillZone")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    public bool clone = false;
    public Explosive boom;
    Transform transf;
    public GameObject point;
    Rigidbody rb;
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
        Explosive clone = (Explosive)Instantiate(boom, point.transform.position, point.transform.rotation);
        clone.clone = true;
        Destroy(gameObject);
    }
}

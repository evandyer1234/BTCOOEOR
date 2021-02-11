using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public bool clone = false;
    public float size = 20;

    public double timer = 2;
    public double startTime = 2;
    public float power = 200;
    float currentSize = 1;
    public int RotationRate = 100;
    // Start is called before the first frame update
    void Start()
    {
        timer = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (clone)
        {
            gameObject.transform.Rotate(RotationRate * Time.fixedDeltaTime * Vector3.up);
            gameObject.transform.Rotate(RotationRate * Time.fixedDeltaTime * Vector3.right);
            transform.localScale += new Vector3(size, size, size) * Time.deltaTime;
            currentSize = currentSize + size;
            
            if (timer < 0)
            {
                Destroy(gameObject);
            }
        }
        timer -= Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        collision.collider.attachedRigidbody.AddExplosionForce(power, transform.position, currentSize);
    }
}

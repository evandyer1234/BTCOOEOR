using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissolve : MonoBehaviour
{
    public float size = 20;
    public double timer = 2;
    public double startTime = 2;
    public bool isClone = false;
    float currentSize = 1;
    // Start is called before the first frame update
    void Start()
    {
        timer = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClone)
        { 
        transform.localScale -= new Vector3(size, size, size) * Time.deltaTime;
        currentSize = currentSize - size;

        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
    timer -= Time.deltaTime;
    }
}

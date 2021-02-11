using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public bool Clone = false;
    public float time = 2f;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Clone)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}

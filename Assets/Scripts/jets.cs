using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jets : MonoBehaviour
{
    public float bigSize = 1f;
    public float smallSize = 0.8f;
    public float Count = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        big();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator big()
    {
        transform.localScale = new Vector3(bigSize, bigSize, bigSize);
        yield return new WaitForSeconds(Count);
        small();
    }
    IEnumerator small()
    {
        transform.localScale = new Vector3(smallSize, smallSize, smallSize);
        yield return new WaitForSeconds(Count);
        big();
    }
}

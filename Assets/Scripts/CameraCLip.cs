using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCLip : MonoBehaviour
{
    public AudioClip gamesBegin;
    public float hitVol = 5f;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClip()
    {
        source.PlayOneShot(gamesBegin, hitVol);
    }
}

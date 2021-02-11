using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class icon : MonoBehaviour
{
    public RawImage pic;
    public Texture texture1;
    public Texture texture2;
    public Texture texture3;
    public Texture texture4;
    int num = 0;
    public float RotationRate;
    EventSystem m_EventSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        num = Random.Range(1, 5);
        m_EventSystem = EventSystem.current;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pic.transform.position = new Vector3(m_EventSystem.currentSelectedGameObject.transform.position.x - 130f, m_EventSystem.currentSelectedGameObject.transform.position.y, m_EventSystem.currentSelectedGameObject.transform.position.z);
        pic.transform.Rotate(RotationRate * Time.fixedDeltaTime * Vector3.forward);
        if (num == 1)
        {
            pic.texture = texture1;
        }
        if (num == 2)
        {
            pic.texture = texture2;
        }
        if (num == 3)
        {
            pic.texture = texture3;
        }
        if (num == 4)
        {
            pic.texture = texture4;
        }
    }
}

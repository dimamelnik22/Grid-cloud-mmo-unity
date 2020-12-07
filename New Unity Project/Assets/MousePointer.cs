using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3((Input.mousePosition.x - Screen.width / 2) / Screen.width * 25, 0f, (Input.mousePosition.y - Screen.height / 2) / Screen.height * 25) ;
        pos.y = 0.5f;
        transform.position = pos;
    }
}

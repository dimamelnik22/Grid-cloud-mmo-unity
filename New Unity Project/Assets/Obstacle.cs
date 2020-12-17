using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        Debug.Log("entered");
        if (obj.gameObject.GetComponent<Bullet>())
            Destroy(obj.gameObject);
    }
}

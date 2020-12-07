using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 15f;
    public float currentBulletTime = 0f;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime*speed);
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.GetComponent<Obstacle>())
            Destroy(this.gameObject);
    }

}

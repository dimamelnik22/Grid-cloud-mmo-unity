using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 15f;
    public float currentBulletTime = 0f;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime*speed);
        currentBulletTime += Time.deltaTime;

        if (currentBulletTime > 5)
        {
            Destroy(this.GameObject);
        }
    }

}

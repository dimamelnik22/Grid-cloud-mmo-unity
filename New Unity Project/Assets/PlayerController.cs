using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10f;
	private PlayerMotor motor;
    public Rigidbody rb;
    public Camera cam;
    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    private Transform bulletSpawned;

    Vector3 mousePos;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");
        mousePos = Input.mousePosition;


	    Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

	    motor.Move(_velocity);
        if (Input.GetMouseButtonDown(0))
        {
            motor.Shoot();
        }
    }

    void Shoot()
    {
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;
    }
}

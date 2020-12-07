using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
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


	    Vector3 _velocity = (Vector3.right * _xMov + Vector3.forward * _zMov).normalized * speed;
        rb.MovePosition(rb.position + _velocity * Time.fixedDeltaTime);

        Vector3 targetRotation =  mousePos - cam.WorldToScreenPoint(rb.position);
        float angle = Mathf.Atan2(targetRotation.x, targetRotation.y) * Mathf.Rad2Deg - 90f;
        rb.rotation = Quaternion.AngleAxis(angle, Vector3.up);

	    // motor.Move(_velocity);

        if (Input.GetMouseButtonDown(0))
        {
           Shoot(); 
        }
    }

    void Shoot()
    {
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;
    }
}

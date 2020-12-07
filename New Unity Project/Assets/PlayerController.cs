using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10f;
	private PlayerMotor motor;
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = Vector3.right * _xMov;
        Vector3 _moveVertical = Vector3.forward * _zMov;

	    Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

	    motor.Move(_velocity);
        if (Input.GetMouseButtonDown(0))
        {
            motor.Shoot();
        }
    }
}

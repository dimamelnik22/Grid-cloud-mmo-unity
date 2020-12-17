using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10f;
	private PlayerMotor motor;
    public GameObject mousePointer;
    public SocketUser socketUser;
    Vector3 mousePos;
	public string text = "a";
    bool shoot = false;
    bool scene = true;
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        socketUser.playerMotor = motor;
    }



    void Update()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");
        mousePos = Input.mousePosition;
        Vector3 _moveHorizontal = Vector3.right * _xMov;
        Vector3 _moveVertical = Vector3.forward * _zMov;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        //Combined direction of pressed buttons
        //motor.Move(motor.transform.position + _velocity*Time.deltaTime);
        //motor.UpdaetePosition(motor.transform.position + _velocity*Time.deltaTime);
        Vector3 newpos = motor.transform.position + _velocity * Time.deltaTime;
        if (_velocity.x !=0f || _velocity.z != 0f)
            socketUser.UpdateEvent(newpos.x, newpos.z, transform.rotation.y, shoot);
        if (Input.GetMouseButtonDown(0))
        {
            //Left Mouse Button to shoot
            //motor.Shoot(mousePointer.transform.position);
            shoot = true;
        }
        else
        {
            shoot = false;
        }
        if (scene)
        {
            //Debug.Log("first update");
            //socketUser.UpdateEvent(newpos.x, newpos.z, transform.rotation.y, shoot);
            //scene = false;
        }
    }
}

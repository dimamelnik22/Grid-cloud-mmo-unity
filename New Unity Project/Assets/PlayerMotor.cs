using UnityEngine;


public class PlayerMotor : MonoBehaviour
{
    public Vector3 velocity = Vector3.zero;
	
	private Rigidbody rb;
    void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
	void  Update()
    {
		
	}
	public void Move(Vector3 _velocity)
	{
		velocity = _velocity;
		// mousePos = _mousePos;
	}
    	void FixedUpdate()
	{
		PerformMovemnt();
		// transform.rotation = Quaternion.identity;
		// Vector2 lookDir = mousePos - (Vector2.right*rb.position.z + Vector2.up*rb.position.x);
		// float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
		// rb.rotation = Quaternion.AngleAxis(angle, Vector3.up);
	}

	void PerformMovemnt()
	{
		if (velocity != Vector3.zero)
		{	
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;

	}
}

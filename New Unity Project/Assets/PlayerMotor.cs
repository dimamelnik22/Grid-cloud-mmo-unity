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
	}
    	void FixedUpdate()
	{
		PerformMovemnt();
		transform.rotation = Quaternion.identity;
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

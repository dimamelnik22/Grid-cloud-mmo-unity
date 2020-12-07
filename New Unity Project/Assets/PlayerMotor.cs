using UnityEngine;


public class PlayerMotor : MonoBehaviour
{
    public Vector3 velocity = Vector3.zero;
	public GameObject mousePointer;
	public GameObject bulletSpawnPoint;
	public GameObject bullet;
	private Transform bulletSpawned;
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

	public void Shoot()
    {
		bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
		bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;
	}
    void FixedUpdate()
	{
		PerformMovemnt();
		Quaternion lookRot = Quaternion.LookRotation(mousePointer.transform.position - this.transform.position);
		transform.rotation = Quaternion.Lerp(this.transform.rotation, lookRot, Time.deltaTime*100);
	}

	void PerformMovemnt()
	{
		if (velocity != Vector3.zero)
		{
			
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}
	}
}

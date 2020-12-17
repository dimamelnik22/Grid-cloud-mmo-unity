using System.Collections;
using UnityEngine;


public class PlayerMotor : MonoBehaviour
{
    public Vector3 velocity = Vector3.zero;
	public Vector3 targetPosition;
	public GameObject mousePointer;
	public GameObject bulletSpawnPoint;
	public GameObject bullet;
	public LineRenderer beam;
	private Transform bulletSpawned;
	private Rigidbody rb;
    void Start ()
	{
		rb = GetComponent<Rigidbody>();
		targetPosition = transform.position;
	}
	void  Update()
    {
		transform.position = targetPosition;
	}
	public void Move(Vector3 pos)
	{
		transform.position = pos;

	}

	public void Shoot(Vector3 target)
    {
		beam.SetPosition(0, bulletSpawnPoint.transform.position);
		beam.SetPosition(1, target);
		beam.enabled = true;
		StartCoroutine(BeamDestruction());
	}
	IEnumerator BeamDestruction()
	{

		yield return new WaitForSeconds(1);
		beam.enabled = false;

	}

	void FixedUpdate()
	{
		
		//PerformMovemnt();
		if (this.GetComponent<PlayerController>())
		{
			Quaternion lookRot = Quaternion.LookRotation(mousePointer.transform.position - this.transform.position);
			rb.MoveRotation(Quaternion.Lerp(this.transform.rotation, lookRot, Time.deltaTime * 100));
		}
	}

	void PerformMovemnt()
	{
		if (velocity != Vector3.zero)
		{	
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}
	}

	public void UpdatePosition(Vector3 pos)
    {
		
		targetPosition = pos;
	}

	public void CatchBeam()
    {
		Destroy(this.gameObject);
    }
}

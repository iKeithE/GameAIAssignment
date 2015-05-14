using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	[Header ("Ship Settings")]
	public Vector3 velocity;
	public Vector3 acceleration;
	public Vector3 force;
	public float mass;
	public float maxSpeed;

	public float speed = 1.0f;

	[Header ("Offset Pursue Settings")]
	public bool offsetPursueEnabled;
	public GameObject offsetPursueTarget;
	public Vector3 offset;



	public Ship()
	{
		mass = 1;
		velocity = Vector3.zero;
		force = Vector3.zero;
		acceleration = Vector3.zero;
		maxSpeed = 1.0f;
		speed = 1.0f;

	}

	// Use this for initialization
	void Start () {
	
		if (offsetPursueEnabled)
		{
			if (offsetPursueTarget != null)
			{
				offset = offsetPursueTarget.transform.position - transform.position;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (offsetPursueEnabled)
		{
			force += OffsetPursue(offsetPursueTarget);
		}

		transform.Translate(Vector3.forward * Time.deltaTime * speed);



	
	}


	Vector3 OffsetPursue(GameObject offsetPursueTarget)
	{
		Vector3 targetPos = offsetPursueTarget.transform.TransformPoint(offset);
		
		Vector3 toTarget = targetPos - transform.position;

		float distance = toTarget.magnitude;
		float time = distance / maxSpeed;

		Vector3 target = targetPos + offsetPursueTarget.GetComponent<Mothership>().velocity * time;

		
		return Arrive(target);
	}


	Vector3 Arrive(Vector3 arriveTarget)
	{
		Vector3 toTarget = arriveTarget - transform.position;
		
		float distance = toTarget.magnitude;
		
		float slowingDistance = 10;

		
		float ramped = (distance / slowingDistance) * maxSpeed;
		float clamped = Mathf.Min(ramped, maxSpeed);
		Vector3 desired = (toTarget / distance) * clamped;
		return desired - velocity;
	}

}

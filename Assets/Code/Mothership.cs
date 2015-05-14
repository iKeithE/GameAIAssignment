using UnityEngine;
using System.Collections;

public class Mothership : MonoBehaviour {

	public float speed = 1.0f;

	public Transform target;
	
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {

		//Move mothership move forward to point
		transform.Translate(Vector3.forward * Time.deltaTime * speed);

		//Check distance between Earth and the Mothership
		float distance = Vector3.Distance (target.position, this.transform.position);
		print (distance);

		if (distance < 80)
		{
			//Change scene here
			print ("Change Scene");
			//Application.LoadLevel ("_Scene2");
		}


	
	}
}

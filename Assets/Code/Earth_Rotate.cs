using UnityEngine;
using System.Collections;

public class Earth_Rotate : MonoBehaviour {

	[Header("Earth Settings")]
	public float rotate_speed = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Rotate Earth around the up vector
		transform.RotateAround (Vector3.zero, Vector3.up, rotate_speed * Time.deltaTime);
	
	}
}

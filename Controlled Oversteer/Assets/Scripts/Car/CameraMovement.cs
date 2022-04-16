using UnityEngine;
using System.Collections.Generic;

public class CameraMovement : MonoBehaviour {

	public Transform player;
	public Vector3 offset;
	public Vector3 offsetdirection;
	public float smoothspeed = 0.125f;
	public float smoothdirection = 0.125f;
	
	
	void FixedUpdate () 
	{
		lookat();
		Follow();
	}



	void lookat()
	{
		Vector3 _lookDir = player.position - transform.position;
		Quaternion rot = Quaternion.LookRotation(_lookDir, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, rot, smoothdirection * Time.deltaTime);
	}

	void Follow()
	{
		Vector3 targetpos = player.position + (player.forward * offset.z + player.right * offset.x + player.up * offset.y);
		transform.position = Vector3.Lerp(transform.position, targetpos, smoothspeed * Time.deltaTime);
	}

	public void switchCamera()
	{
		offset.z = offset.z * -1;
	}


}

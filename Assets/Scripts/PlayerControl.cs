using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public GameObject CameraOrb;
	public float speed;
	private float movementX;
	private float movementY;
	private Rigidbody rb;
	private Vector3 movement;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		print(movementX + "   " + movementY);
		movement = new Vector3(0.0f, movementY, movementX);

		rb.AddForce(movement * speed);

	}


	public void OnMove(InputValue value)
	{
		Vector2 v = value.Get<Vector2>();

		movementX = v.x;
		movementY = v.y;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Stage_1"))
		{
			rb.velocity = new Vector3(0,0,0);
			transform.position = new Vector3(13f, 23.1f, -15.5f);
			CameraOrb.transform.Rotate(0.0f, 90.0f, 0.0f,Space.Self);
			movement = new Vector3(movementX, movementY, 0.0f);
		}
		if (other.gameObject.CompareTag("Stage_2"))
		{
			rb.velocity = new Vector3(0, 0, 0);
			transform.position = new Vector3(-15.5f, 18.3f, -13f);
			CameraOrb.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
			movement = new Vector3(0.0f, movementY, -movementX);
		}
		if (other.gameObject.CompareTag("Stage_3"))
		{
			rb.velocity = new Vector3(0, 0, 0);
			transform.position = new Vector3(-13, 5, -13);
			CameraOrb.transform.Rotate(0.0f, -90.0f, -90.0f, Space.Self);
			movement = new Vector3(-movementX, 0.0f, movementY);
		}
		if (other.gameObject.CompareTag("Stage_4"))
		{
			rb.velocity = new Vector3(0, 0, 0);
			transform.position = new Vector3(12, 8, -16);
			CameraOrb.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
			movement = new Vector3(-movementX, movementY, 0.0f);
		}
		if (other.gameObject.CompareTag("Death"))
		{
			rb.velocity = new Vector3(0, 0, 0);
			transform.position = new Vector3(11, 8, 16);
		}
		if (other.gameObject.CompareTag("Stage_5"))
		{
			rb.velocity = new Vector3(0, 0, 0);
			transform.position = new Vector3(6, 36, 14);
			CameraOrb.transform.Rotate(0.0f, -90.0f, 90.0f, Space.Self);
			movement = new Vector3(-movementX, 0.0f, -movementY);
		}

	}
	
}

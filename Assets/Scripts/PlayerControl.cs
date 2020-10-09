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
	private int faceNum;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezePositionX;
		faceNum = 1;
	}

	void FixedUpdate()
	{
		print(movementX + "   " + movementY);
        switch (faceNum)
        {
			case 1:
				movement = new Vector3(0.0f, movementY, movementX);
				break;
			case 2:
				movement = new Vector3(movementX, movementY, 0.0f);
				break;
			case 3:
				movement = new Vector3(0.0f, movementY, -movementX);
				break;
			case 4:
				movement = new Vector3(-movementX, 0.0f, movementY);
				break;
			case 5:
				movement = new Vector3(-movementX, movementY, 0.0f);
				break;
			case 6:
				movement = new Vector3(-movementX, 0.0f, -movementY);
				break;
		}

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
			rb.velocity = new Vector3(0, 0, 0);
			faceNum = 2;
			rb.constraints = RigidbodyConstraints.FreezePositionZ;
			transform.position = new Vector3(13f, 23.1f, -15.5f);
			CameraOrb.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
		}
		if (other.gameObject.CompareTag("Stage_2"))
		{
			rb.velocity = new Vector3(0, 0, 0);
			faceNum = 3;
			rb.constraints = RigidbodyConstraints.FreezePositionX;
			transform.position = new Vector3(-15.5f, 18.3f, -13f);
			CameraOrb.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
		}
		if (other.gameObject.CompareTag("Stage_3"))
		{
			rb.velocity = new Vector3(0, 0, 0);
			faceNum = 4;
			rb.constraints = RigidbodyConstraints.FreezePositionY;
			transform.position = new Vector3(-12.5f, 4.5f, -12.5f);
			CameraOrb.transform.Rotate(0.0f, 90.0f, -90.0f, Space.Self);
		}
		if (other.gameObject.CompareTag("Stage_4"))
		{
			rb.velocity = new Vector3(0, 0, 0);
			faceNum = 5;
			rb.constraints = RigidbodyConstraints.FreezePositionZ;
			transform.position = new Vector3(11.5f, 8f, 15.5f);
			CameraOrb.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
		}
		if (other.gameObject.CompareTag("Death"))
		{
			rb.velocity = new Vector3(0, 0, 0);
			transform.position = new Vector3(11.5f, 8f, 15.5f);
		}
		if (other.gameObject.CompareTag("Stage_5"))
		{
			rb.velocity = new Vector3(0, 0, 0);
			faceNum = 6;
			rb.constraints = RigidbodyConstraints.FreezePositionY;
			transform.position = new Vector3(5.5f, 35.5f, 13.5f);
			CameraOrb.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
		}

	}

}

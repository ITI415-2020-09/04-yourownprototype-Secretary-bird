using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

	public float speed;

	private float movementX;
	private float movementY;

	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		print(movementX + "   " + movementY);
		Vector3 movement = new Vector3(0.0f, movementY, movementX);

		rb.AddForce(movement * speed);

	}


	public void OnMove(InputValue value)
	{
		Vector2 v = value.Get<Vector2>();

		movementX = v.x;
		movementY = v.y;
	}

}

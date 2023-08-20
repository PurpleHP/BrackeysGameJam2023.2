using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	[SerializeField] float speed = 5f;

	void Start()
	{
	}

	void Update()
	{
		transform.position += transform.right * speed  * Time.deltaTime;
	}
}
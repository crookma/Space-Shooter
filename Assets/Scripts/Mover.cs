/* Magnus Crooke
 * 3-5-18
 * This code is responsible for your player, pickups, text updates, and more.
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour 
{
	private Rigidbody rb;
	public float speed; // speed of lasers
	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed; // speed of lasers
	}
}

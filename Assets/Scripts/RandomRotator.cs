/* Magnus Crooke
 * 3-5-18
 * This code is responsible for your player, pickups, text updates, and more.
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour 
{
	public float tumble; // rotation of the asteroids
	private Rigidbody rb;

	void Start() // Rotates the asteroids
	{
		rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
}


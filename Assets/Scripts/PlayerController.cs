/* Magnus Crooke
 * 3-5-18
 * This code is responsible for your player, pickups, text updates, and more.
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax; // Position of plaer on screen
}

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb; 
	private AudioSource ac; // Audio for explosions
	public float speed; // speed of player
	public float tilt; // tilt of player
	public Boundary boundary; // Restricting boundary on screen boundary

	public GameObject shot; // spawns lasers
	public Transform shotSpawn; // spawns lasers
	public float fireRate; // Firerate of player

	private float nextFire; // Firerate of player

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		ac = GetComponent<AudioSource> ();
	}
	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) // Firerate
		{
			nextFire = Time.time + fireRate; // Firerate
			Instantiate (shot, transform.position, transform.rotation); // as GameObject;
			ac.Play ();
		}


	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal"); // Moves player up and down on screen
		float moveVertical = Input.GetAxis ("Vertical"); // Moves player side to side on screen

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); // movement of player
		rb.velocity = movement * speed;

		rb.position = new Vector3 // Position on the screen and the invisible boundary
			(
				Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
			);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}


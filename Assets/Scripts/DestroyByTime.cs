/* Magnus Crooke
 * 3-5-18
 * This code is responsible for your player, pickups, text updates, and more.
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour 
{
	public float lifetime; // Triggers the destruction of the asteriods and lasers

	void Start()
	{
		Destroy (gameObject, lifetime); // Destroys the asteriods and lasers
	}
}

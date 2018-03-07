/* Magnus Crooke
 * 3-5-18
 * This code is responsible for your player, pickups, text updates, and more.
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit(Collider other){ // Destroys asteroids and lasers when they exit the screen
		Destroy (other.gameObject);
	}
}
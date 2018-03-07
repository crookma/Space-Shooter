/* Magnus Crooke
 * 3-5-18
 * This code is responsible for your player, pickups, text updates, and more.
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion; // Makes an explosion for the asteroids
	public GameObject playerexplosion; // Explosion for the plaer
	public int scoreValue; // Total score
	private GameController gameController; // Controls the game

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController"); // Controls the game
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script"); // Debugs the script
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Boundary") // Boundary Zone that triggers explosions
		{
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation); // as GameObject;
		if (other.tag == "Player") {
			Instantiate (playerexplosion, other.transform.position, other.transform.rotation); // as GameObject;
			gameController.GameOver (); // Explodes the player when hit
		}
		gameController.AddScore (scoreValue); // Adds score
		Destroy (other.gameObject); // Destroys asteroids and lasers
		Destroy (gameObject); // Destroys the player
	}
}

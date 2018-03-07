/* Magnus Crooke
 * 3-5-18
 * This code is responsible for your player, pickups, text updates, and more.
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	public GameObject hazard; // Asteroids
	public Vector3 spawnValues; // Amount of asteroids spawning
	public int hazardCount; // Amount of asteroids spawning at a time
	public float spawnWait; // Time in between the spawning of asteroids
	public float startWait; // Sets start time
	public float waveWait; // Time to spawn next waves
	public Text scoreText; // Score Display
	private int score; // Total score
	public Text restartText; // Restart Display
	public Text gameOverText; // Game over Display

	private bool gameOver; // Displays game over text
	private bool restart; // Displays restart text 

	void Start ()
	{
		gameOver = false; // Doesn't end game
		restart = false; // Doesn't restart game
		restartText.text = ""; // restart text
		gameOverText.text = ""; // game over text
		score = 0; // score set to zero
		UpdateScore() ; 
		StartCoroutine (SpawnWaves ()); // Spawns asteroid waves
	}

	void Update ()
	{
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) { // Press 'r' to restart
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait); // Time until next asteroid wave
		while (true)
		{	
			for (int i = 0; i < hazardCount; i++) // Spawns asteroids
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z); // Randon spawn location of asteroids
				Quaternion spawnRotation = Quaternion.identity; // rotation speed of the asteroids
				Instantiate (hazard, spawnPosition, spawnRotation); // random position and rotation on the screen
				yield return new WaitForSeconds (spawnWait); // Asteroid spawn waves waiting time
			}
			yield return new WaitForSeconds (waveWait); // Updates next spawnwave

			if (gameOver) {
				restartText.text = "Press 'R' for Restart"; // Press 'R' to restart
				restart = true;
				break;
			}
		}
	
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue; // Adds score
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score.ToString (); // Updates score on screen
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!"; // Displays game over when the player has been hit
		gameOver = true;
	}
}
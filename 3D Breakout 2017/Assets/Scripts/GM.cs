using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // for scene managemant

public class GM : MonoBehaviour {

	public static int lives = 3;
	public int ball_num = 0;
	public int bricks = 21;
	public float resetDeley = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWin;
	public GameObject thanks;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject ballPrefab;
	public GameObject cloneBall;
//	public ArrayList cloneBallList;
	public List<GameObject> cloneBallList = new List<GameObject>();
	public GameObject deathParticles;
	public GameObject ballParticles;
	public GameObject attachedBall = null; // used in Paddle.cs to let the ball go with the paddle while attaching on the paddle
	public static GM instance = null; // GM.instance.brick_num

	private GameObject clonePaddle;
	private GameObject [] _bricks; // use to untrigger the bricks

	public SceneFader sceneFader;

	void Start(){
//		lives = 3;
//		instance.ball_num = 0;
//		instance.bricks = 21;
//		ScoreManager.score = 0;
//		ballPrefab = GameObject.Find("Ball(Clone)");
//		SpawnBall();
//		cloneBallList = new ArrayList();
	}

	// to eusure there is only "one" GM
	void Awake () {
		if (instance == null){
			instance = this;
		}
		else if (instance != this){
			Destroy (gameObject);
		}

		Setup();
	}
		
	// setup the game at the beginning
	public void Setup(){
//		livesText.text = "Lives: " + lives;
		// set the default information, including lives score

//		if (SceneManager.GetActiveScene ().name == "Scene1") {
			lives = 3;
			ball_num = 0;
//			bricks = 35;
			ScoreManager.score = 0;
//		}

		livesText.text = lives.ToString();

		Instantiate(bricksPrefab, transform.position, Quaternion.identity);
//		SpawnBall ();
		SetupPaddle();
	}

	void CheckGameOver(){
		if (bricks < 1)
		{
			// destroy all of the player
			GameObject [] ballsToInactive = GameObject.FindGameObjectsWithTag ("Ball");
			GameObject playerToInactive = GameObject.FindGameObjectWithTag ("Player");
			foreach (GameObject ball_member in ballsToInactive) {
				if (ball_member != null) {
					ball_member.SetActive (false);
				}	
			}

			playerToInactive.SetActive (false);

			Debug.Log ("You win!");
			youWin.SetActive(true);
			FindObjectOfType<AudioManager>().Play("WinMusic");
			Invoke ("NextLevel", 3f);
		}

		if (lives < 1)
		{
			gameOver.SetActive(true);
			Invoke ("Reset", 3f);
		} 
	}

	void Reset(){
		Time.timeScale = 1f;
		//Application.LoadLevel (Application.loadedLevel);
		lives = 3;
		ScoreManager.score = 0;
		int sceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene("Menu");
		//Application.LoadLevel ("Scene1");
	}

	void NextLevel(){
		Time.timeScale = 1f;

		int sceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (SceneManager.GetActiveScene ().name != "Scene2") {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		}

		else if (SceneManager.GetActiveScene ().name == "Scene2") {
			sceneFader.FadeTo ("Menu");
		}
	}

	public void LoseLife()
	{
		GameObject CounDownText = GameObject.Find("CountDownText");
		CountDown CountDownScript = CounDownText.GetComponent<CountDown> ();
//		CountDownScript.count = false;

		// finish the powerUp 
		CountDownScript.timeLeft = -2f;

		lives--;
		livesText.text = lives.ToString();
		GameObject newexplosion = Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(newexplosion,1);
		Destroy(clonePaddle);
		DestroyBall (); // when the paddle die, the ball also need to be destroyed

		DestroyAllPowerup("Powerup");
		DestroyAllPowerup("Powerdown");

		// if the game is over, stop to setup the paddle
		if (lives >= 1) {
			Invoke ("SetupPaddle", resetDeley);
		}

		CheckGameOver();
	}

	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
		SpawnBall ();

		_bricks = GameObject.FindGameObjectsWithTag ("Brick"); // use to enable the trigger of the bricks
		// untrigger the bricks 
		foreach (GameObject Brick in _bricks) {
			if (Brick != null) {
				Brick.GetComponent<Bricks> ().SetNotTrigger ();
			}	
		}

	}

	public void SpawnBall() {
		
		// Spawn new ball
		if( ballPrefab == null ) {
			Debug.Log ("Hey, dummy, you forgot to link to the ball prefab in the inspector!");
			return;
		}

//		attachedBall = Instantiate( ballPrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity ) as GameObject;
		attachedBall = Instantiate(ballPrefab) as GameObject;
//		cloneBall = attachedBall;
		AddNewCloneBall(attachedBall);
		ball_num++;
	}

	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver();
	}

	public void DestroyBall() // while get too much powerdownShrink, destroy all of the ball
	{

		for (int i = 0; i < cloneBallList.Count; i++) {
			GameObject newexplosion = Instantiate (ballParticles, cloneBallList[i].transform.position, Quaternion.identity);
			Destroy(newexplosion,1);

			Destroy (cloneBallList [i]);
		}
			
		cloneBallList.Clear (); // clear the cloneBallList
	}

	public void DestroyAllPowerup(string tagName){
		GameObject [] powerups = GameObject.FindGameObjectsWithTag (tagName);

		for(var i = 0 ; i < powerups.Length ; i ++)
		{
			Destroy(powerups[i]);
		}
	}

	public void AddNewCloneBall(GameObject newCloneBall){
		cloneBallList.Add(newCloneBall);
	}

	public void RemoveCloneBall(GameObject newCloneBall){
		cloneBallList.Remove(newCloneBall);
	}
}

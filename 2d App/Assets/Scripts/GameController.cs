using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

  	public AudioSource spamMusic;
	public AudioSource goodMusic;
	private AudioSource currentMusic;

    public static float downSpeed = -2f;
    public static bool hasStarted = true;
    public static bool isRunning = true;
	public static float deathY = -10.5f;
	public static float stickTimer = 0.1f;

	//3DF49900
	//1AC5CCFF

    public GameObject endPanel;
    public Text UIscore;
    public GameObject currentPanel;
    public Text currentScore;

	public static int score = 0;
    static int previousScore = 0;

	void Start() {
		if (Debug.isDebugBuild) {
			currentMusic = goodMusic;
		} else {
			currentMusic = spamMusic;
		}
        isRunning = true;
        downSpeed = -2f;
        hasStarted = true;
        currentPanel.SetActive(true);
        endPanel.SetActive(false);
        previousScore = (int)Time.time;
        score = 0;
		currentMusic.Play ();
	}

    public void restartGame() {
		isRunning = true;
		downSpeed = -2f;
		hasStarted = true;
		currentPanel.SetActive (true);
		endPanel.SetActive (false);
		previousScore = (int)Time.time;
		score = 0;
		SceneManager.LoadScene (1);
	}

    public void goToHome() {
       SceneManager.LoadScene(0);
    }

    public void endGame() {
		isRunning = false;
		downSpeed = 0f;
		if (score > PlayerPrefs.GetInt("highScore")) {
			PlayerPrefs.SetInt ("highScore", score);
		}
		UIscore.text = "Score: " + score + "\nBest: " + PlayerPrefs.GetInt ("highScore");
		currentPanel.SetActive (false);
		endPanel.SetActive (true);
	}

    void Update() {
		if (isRunning)
			setScore ();
	}

    void setScore() {
		currentScore.text = "" + score;
		score = (int)Time.time - previousScore;
	}

	public static void moveDown(Transform t){
		t.Translate (new Vector2 (0, GameController.downSpeed * Time.deltaTime));
	}
}

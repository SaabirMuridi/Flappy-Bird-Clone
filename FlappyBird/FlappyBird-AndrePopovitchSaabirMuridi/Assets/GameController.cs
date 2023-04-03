using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class GameController : MonoBehaviour {
    public float gameMoveSpeed = 4;
    public float aspectRatio = 16 / 9;
    public GameObject deathWords;
    public float points = 0;
    public static float highScore = 0;
    bool gameOver = false;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;


    public float getScreenWidth()
    {
        return GetComponent<Camera>().orthographicSize * aspectRatio * 2;
    }
    public float getScreenLeftEdge ()
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0,0,0)).x;
    }
    public Vector3 getCenterOfScreen()
    {
        var screenCords = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        return GetComponent<Camera>().ScreenToWorldPoint(screenCords);
    }

    public void GameOver()
    {
        deathWords.SetActive(true);
        deathWords.transform.position = getCenterOfScreen();
        deathWords.transform.position = new Vector3(deathWords.transform.position.x, deathWords.transform.position.y, 10);
        gameOver = true;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gameOver && (Input.GetKeyDown(KeyCode.Space) ||  Input.GetMouseButtonDown(0)) )
        {
            SceneManager.LoadScene("SampleScene");
        }

        var scoreCharsAnnotated = "";
        foreach (char c in points.ToString())
        {
            scoreCharsAnnotated +=  "<sprite name=\"Number" + c + "\">";
        }
        scoreText.text = scoreCharsAnnotated;

        if (GameController.highScore < points)
        {
            GameController.highScore = points;
        }


        scoreCharsAnnotated = "";
        foreach (char c in GameController.highScore.ToString())
        {
            scoreCharsAnnotated += "<sprite name=\"Number" + c + "\">";
        }
        highScoreText.text = scoreCharsAnnotated;

    }
}

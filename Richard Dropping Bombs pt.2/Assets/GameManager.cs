using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    private Spawner spawner;
    public GameObject title;
    private Vector2 screenBounds;
    [Header("Player")]
    public GameObject playerPrefab;
    public GameObject splash;
    private GameObject player;
    private bool gameStarted = false;
    public Text scoreText;
    public int pointsWorth = 1;
    private int score;

    private int bestScore = 0;
    public TMP_Text bestScoreText;
    private bool beatBestScore;


    private bool smokeCleared = true;
    private void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        scoreText.enabled = false;

        bestScoreText.enabled = false;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        spawner.active = false;
        title.SetActive(true);
        splash.SetActive(false);

        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = "Best Score:" + bestScore.ToString();
    }


    // Update is called once per frame
    void Update() {
        if (!gameStarted) {

            if (Input.anyKeyDown)
            {
                ResetGame();
            }

        }
        else
        {
            if (!player)
            {
                OnPlayerKilled();
            }

        }

        if (Input.anyKeyDown)
        {
            spawner.active = true;
            title.SetActive(false);

        }

        var nextBomb = GameObject.FindGameObjectsWithTag("Bomb");

        foreach (GameObject bombObject in nextBomb) {
            
            if (bombObject.transform.position.y < (-screenBounds.y - 12)) {
                Debug.Log("sssss");
                if (gameStarted) {
                
                    score += pointsWorth;
Debug.Log(score);
                    scoreText.text = "Score: " + score.ToString();
                    Debug.Log("Score: " + score.ToString());
                }
                Destroy(bombObject);
            }
        }
    }


  

    void ResetGame()
    {
        spawner.active = true;
        title.SetActive(false);

        splash.SetActive(false);

        scoreText.enabled = true;
        score = 0;

        beatBestScore = false;
        bestScoreText.enabled = true;

        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), playerPrefab.transform.rotation);
        gameStarted = true;

    }

    void OnPlayerKilled()
    {

        spawner.active = false;
        gameStarted = false;

        splash.SetActive(true);

        Invoke("SPlashScreen", 2);
         if(score > bestScore)
            {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            beatBestScore = true;
            bestScoreText.text = "Best Score: " + bestScore.ToString();
        }


    }
}

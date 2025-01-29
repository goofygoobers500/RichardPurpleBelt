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
    private void Awake()


    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    // Start is called before the first frame update
    void Start()
    {
        spawner.active = false;
        title.SetActive(true);
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

        foreach (GameObject bombObject in nextBomb)
            if (bombObject.transform.position.y < (-screenBounds.y - 12))
            {

                if (gameStarted)
                {

                    score += pointsWorth;
                    scoreText.text = "Score: " + score.ToString();
                }
                Destroy(bombObject);
            }
    }

    void ResetGame()
    {
        spawner.active = true;
        title.SetActive(false);

        splash.SetActive(false);

        scoreText.enabled = true;
        score = 0;

        scoreText.text = "Score: " + score.ToString();

        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), playerPrefab.transform.rotation);
        gameStarted = true;

    }

    void OnPlayerKilled()
    {

        spawner.active = false;
        gameStarted = false;

        splash.SetActive(true);


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{


    private Spawner spawner;
    public GameObject title;
    private Vector2 screenBounds;
    [Header("Player")]
    public GameObject playerPrefab;
    private GameObject player;
    private bool gameStarted = false;
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
                Destroy(bombObject);
            }
    }

    void ResetGame()
    {
        spawner.active = true;
        title.SetActive(false);

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

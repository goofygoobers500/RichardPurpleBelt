using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    // I was grading your project and I had to fix some errors so I could run the game, but dw I put the errors back
    // Hint: Even though you created a new script, two scripts can't share the same namespace, that's the thing before
    // the : MonoBehaviour
    // - Sensei Tim
    [Header("Game Over UI Canvas Object")]
    public GameObject gameOverCanvas;

    public GameObject platform;

    float pos = 0;

    // Start is called before the first frame update 
    void Start()
    
    {
        for(int i = 0; i < 100; i++)
        SpawnPlatforms();
    }

    // Update is called once per frame
    void Update()
    {

    }

void SpawnPlatforms()
    {

        Instantiate(platform, new Vector3(Random.value * 10 - 5f, pos, 0.5f), Quaternion.identity);
        pos += 10.5f;
    }
    public void GameOver()
    {


        gameOverCanvas.SetActive(true); 
    }


}


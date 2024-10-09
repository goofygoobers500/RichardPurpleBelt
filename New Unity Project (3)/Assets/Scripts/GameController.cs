using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("Spawn", spawnDelay, spawnTime);

    }

    // Update is called once per frame
    void Update()
    {

    }


    public GameObject[] shapePrefabs;


    public float spawnDelay = 2f;

    public float spawnTime = 3f;


    void Spawn()
    {

        int randomInt = Random.Range(0, shapePrefabs.Length);


        Instantiate(shapePrefabs[randomInt], Vector3.zero, Quaternion.identity);
    }

    public void GameOver()
    {

        CancelInvoke("Spawn");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
public float moveSpeed = 600f;
    public Transform rizz;

    float movement = 0f;

    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {

        movement = Input.GetAxisRaw("Horizontal");
        Debug.Log(Time.timeScale);

    }

    

     void FixedUpdate()
    {

        rizz.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("GameController").GetComponent<GameController>().GameOver();
    }
}

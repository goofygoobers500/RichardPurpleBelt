using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControls: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1f;

        StartCoroutine(CountTime());

        timerText = GameObject.Find("Score").GetComponent<Text>();

    }

    // Update is called once per frame
    IEnumerator CountTime()
    {

        yield return new WaitForSeconds(1f);
        timerCount++;
        timerText.text = "Score: " + timerCount;
        StartCoroutine(CountTime());
    }

    private Text timerText;

    private int timerCount;
}

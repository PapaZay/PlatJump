using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject[] spawnPoints;
    public float timer;
    public float TimeBetweenSpawns;

    public float speedMultiplier;
    private float distance;
    public TextMeshProUGUI distanceUI;

    private float HighScore;
    public TextMeshProUGUI HighScoreUI;
    
    
    void Start()
    {
        HighScore = PlayerPrefs.GetFloat("HighScore", 0f);
        HighScoreUI.text = "HighScore: " + HighScore.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {

        distanceUI.text = "Distance: " + distance.ToString("F2");
        speedMultiplier += Time.deltaTime * 0.05f;
        timer += Time.deltaTime;
        distance += Time.deltaTime * 0.8f;
        //HighScoreUI.text = "HighScore: " + HighScore.ToString("F2");

        if(timer > TimeBetweenSpawns){
            timer = 0;
            int randomNum = Random.Range(0, 3);
            Instantiate(spawnObject, spawnPoints[randomNum].transform.position, Quaternion.identity);
        }

        if(distance > HighScore){
            HighScore = distance;
            HighScoreUI.text = "HighScore: " + HighScore.ToString("F2");

            PlayerPrefs.SetFloat("HighScore", HighScore);
            PlayerPrefs.Save(); 
        }
    }
}

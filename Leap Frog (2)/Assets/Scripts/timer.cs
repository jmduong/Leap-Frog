using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class timer : MonoBehaviour
{
    private PlayerController playerControllerScript;

    public GameObject gameOverText;
    public GameObject victoryText;

    private Text timeText;

    private int exportOnce;
    private int lilyCounter;
    private float gameTime;

    private bool started = false;

    //File to record the data
    public StreamWriter file;
    private String filename;
    private String status;


    // Use this for initialization
    void Start()
    {
        timeText = GetComponent<Text>();
        playerControllerScript = GameObject.Find("Cube").GetComponent<PlayerController>();

        //TODO need to add the user name to the file
        filename = "data_" + System.DateTime.Now.ToString("MM-dd-yy_hh-mm-ss") + ".txt";
        file = new StreamWriter(filename);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("2"))
        {
            started = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lilyCounter = playerControllerScript.lilyCount;
        
        //Start the Game and track time.
        if (gameOverText.activeSelf == false && victoryText.activeSelf == false && started)
        {
            gameTime += Time.deltaTime;
            timeText.text = "Time: " + gameTime;
            timeText.text = string.Format("Time: {0:#.00} sec", gameTime);
        }
        else if(gameOverText.activeSelf == true || victoryText.activeSelf == true)
        {
            RecordResult();
        }
    }

    private void RecordResult()
    {
        if(exportOnce == 0)
        {
            if (gameOverText.activeSelf == true)
            {
                status = "GAME OVER";
            }
            else if (victoryText.activeSelf == true)
            {
                status = "Victory";
            }
            Debug.Log("Works");
            exportOnce++;
            file.Write("Time played: " + gameTime.ToString()  + " seconds" + "\t" + " Jumps: " + lilyCounter + "\t" + "Jump Order & Relative Position: " + playerControllerScript.jumpOrder + "\t" + status.ToString() + "\n");
            file.Close();
        }
    }
}

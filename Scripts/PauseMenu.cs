using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject pauseMenu;
    [SerializeField] TextMeshProUGUI textTime;
    [SerializeField] TextMeshProUGUI textDate;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI nickname;
    private int hour;
    private int minute;
    private int day;
    private int month;
    private int year;
    public static bool isPaused = false;
    private Scene scene;
    public bool touch = false;
    public bool touchBoss = false;
    [SerializeField] GameObject[] filters;
    [SerializeField] private MusicManager music;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        //switch for upadating the collection menu in pause menu 
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                destroy(0);
                break;
            case 2:
                destroy(2);
                break;
            case 3:
                destroy(4);
                break;
            case 4:
                destroy(6);
                break;
        }


        TimeUpdate();
        DateUpdate();
        levelUpdate();
        Nickname();
        //input for escape key 
        if (Input.GetKey(KeyCode.Escape))
        {
            GameObject player = GameObject.FindWithTag("Player");
            //chcks if player is dead
            if (player.GetComponent<Health>().isDead == false)
            {
                Pause();
                //Cursor.visible = true;
            }
        }   
    }

    

    public void Resume()
    {
        //turns off the pauseMmenu object
        pauseMenu.SetActive(false);
        //turns on the time continuing
        Time.timeScale = 1f;
        //sets isPaused to false
        isPaused = false;

        //turns up the volume
        music.volumeUp();
        //turns off the cursor visibility
        //Cursor.visible = false;
    }

    public void Pause()
    {
        //turns on the pauseMmenu object
        pauseMenu.SetActive(true);
        //turns off the time continuing
        Time.timeScale = 0f;

        //turns down the volume;
        music.volumeDownd();

        //sets isPaused to false
        isPaused = true;
        //turns on the cursor visibility
        //Cursor.visible = true;
    }

    public void ToMainMenu()
    {
        //loads scene with index 0 (Main Menu)
        SceneManager.LoadScene(0);
        //turns on the time continuing
        Time.timeScale = 1f;

        //sets isPaused to false
        isPaused = false;

        //destroys specific objects which can't be destroy by loading another scene when accessing menu from another scene than default object scene
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Destroy(GameObject.FindGameObjectWithTag("pauseMenu"));
            Destroy(GameObject.FindGameObjectWithTag("UI"));
            Destroy(GameObject.FindGameObjectWithTag("DeathScreen"));
        }



    }

    //method for current time update in pause menu
    public void TimeUpdate()
    {
        
        hour = System.DateTime.Now.Hour;
        minute = System.DateTime.Now.Minute;

        if (minute < 10)
        {
            textTime.text = "" + hour + ":0" + minute;
        }
        else
        {
            textTime.text = "" + hour + ":" + minute;
        }
    }

    //method for current date update in pasue menu
    public void DateUpdate()
    {
        day = System.DateTime.Now.Day;
        month = System.DateTime.Now.Month;
        year = System.DateTime.Now.Year;

        //textDate.GetComponent<Text>().text = "" + day + "." + month + "." + year;
        textDate.text = "" + day + "." + month + "." + year;
    }

    //method for current level update in pause menu
    public void levelUpdate()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                levelText.text = "1.A";
                break;
        }

        levelText.text = SceneManager.GetActiveScene().buildIndex + ".A";
    }

    //nickname setter for pause menu 
    public void Nickname()
    {
        string nick = PlayerPrefs.GetString("nick");
        nickname.text = nick;
    }

    //method to destroy filters in collection menu
    public void destroy(int index)
    {
        if (touch)
        {
            Destroy(filters[index]);
        }
        if (touchBoss)
        {
            Destroy(filters[index + 1]);
        }
    }

    //getter for isPaused
    public bool getIsPaused()
    {
        return isPaused;
    }
}


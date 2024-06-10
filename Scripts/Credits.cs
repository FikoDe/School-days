using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTime;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreTimeUpdate();
        
    }

    public void toMenu()
    {
        //loads scene with index 0 (Main Menu)
        SceneManager.LoadScene(0);
        //turns on the time continuing
        Time.timeScale = 1f;

        //destroys specific objects which can't be destroy by loading another scene when accessing menu from another scene than default object scene
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Destroy(GameObject.FindGameObjectWithTag("pauseMenu"));
            Destroy(GameObject.FindGameObjectWithTag("UI"));
            Destroy(GameObject.FindGameObjectWithTag("DeathScreen"));
        }

    }

    //method for displaying score
    public void scoreTimeUpdate()
    {
        scoreTime.text = "YOUR TIME: " + player.GetComponent<Timer>().getMinutes() + ":" + player.GetComponent<Timer>().getSeconds();
    }

}

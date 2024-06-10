using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_switch: MonoBehaviour
{
    private Scene scene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //initializations of variables which represent gameObject that can't be destroyed
        scene = SceneManager.GetSceneByName("Level2");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject pauseMenu = GameObject.FindGameObjectWithTag("pauseMenu");
        GameObject UI = GameObject.FindGameObjectWithTag("UI");
        GameObject deathScreen = GameObject.FindGameObjectWithTag("DeathScreen");
        GameObject.FindObjectOfType<PauseMenu>().touch = false;
        GameObject.FindObjectOfType<PauseMenu>().touchBoss = false;

        //condition which checks that the player want to go to next level or main menu
        if (collision.tag == "Player" && collision.GetComponent<Item_pick>().numberOfCertificates >= SceneManager.GetActiveScene().buildIndex)
        {
            Debug.Log("posuvam");
            //loads next scene and move player object to [0;0]
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            player.transform.position = player.transform.position - player.transform.position;
        }
    }
}

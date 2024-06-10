using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_triger : MonoBehaviour
{
    public Scene scene;
    [SerializeField] private GameObject musicManager;

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
            //moves necessary objects to another scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.MoveGameObjectToScene(UI, SceneManager.GetSceneByName("Level2"));
            SceneManager.MoveGameObjectToScene(pauseMenu, SceneManager.GetSceneByName("Level2"));
            SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName("Level2"));
            SceneManager.MoveGameObjectToScene(deathScreen, SceneManager.GetSceneByName("Level2"));
            SceneManager.MoveGameObjectToScene(musicManager, SceneManager.GetSceneByName("Level2"));

            //dont destroy this object when loads next scene
            DontDestroyOnLoad(UI);
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(pauseMenu);
            DontDestroyOnLoad(deathScreen);
            DontDestroyOnLoad(musicManager);
            player.transform.position = player.transform.position - player.transform.position;
        }
    }
}

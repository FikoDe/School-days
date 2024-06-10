using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
  public TMP_InputField InputField;
  //method play whych switches scenes 
  public void PlayGame()
    {
        //switches scene to current scene index + 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //turns on the time continuing
        Time.timeScale = 1f;
        //turns on the cursor visibility
    }
    //method quit which exits whole game
    public void QuitGame()
    {
        //quits the game 
        Application.Quit();
    }
    private void Update()
    {
        //sets input from inputField to nick variable in PlayerPrefs file
        PlayerPrefs.SetString("nick", InputField.text);
    }

}



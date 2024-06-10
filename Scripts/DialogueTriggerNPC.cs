using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class DialogueTriggerNPC : MonoBehaviour
{
    public DialogueNPC dialogue;
    public GameObject dialogueWindow;
    public GameObject heart;
    public int npcItems = 0;
    public GameObject[] itms;
    //public bool touch = false;

    //method to trigger dialogue
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManagerNPC>().StartDialogue(dialogue);
    }


    //method for dialogue start when player hits specific position
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //Destroy(filter[SceneManager.GetActiveScene().buildIndex - 1]);
        if (collision.tag == "Player")
        {
            //sets variable touch in PauseMenu to true 
            GameObject.FindObjectOfType<PauseMenu>().touch = true;
            //Debug.Log(itms.Length);
            if (npcItems < itms.Length)
            {
                //GetComponent<BoxCollider2D>().enabled = false;
                dialogueWindow.SetActive(true);
                TriggerDialogue();
                for (int i = 0; i < itms.Length; i++)
                {
                    itms[i].SetActive(true);
                }
            }
            else
            {
                //GetComponent<BoxCollider2D>().enabled = false;
                heart.SetActive(true);
            }


        }



    }
}

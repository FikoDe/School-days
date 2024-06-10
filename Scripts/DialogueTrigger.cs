using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogueWindow;
    public GameObject triggerer;

    //method to trigger dialogue
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
    }

    //method for dialogue start when player hits specific position
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (collision.tag == "Player")
        {
            //sets variable touchBoss in PauseMenu to true 
            GameObject.FindObjectOfType<PauseMenu>().touchBoss = true;
            GetComponent<BoxCollider2D>().enabled = false;
            dialogueWindow.SetActive(true);
            TriggerDialogue();
            
        }
        
    }
}

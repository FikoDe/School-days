using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogManagerNPC : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI dialogueText;
    private Queue<string> sentences;

    public GameObject ContinueButton;

    public Animator animator;
    public GameObject triggerer;

    // Start is called before the first frame update
    void Start()
    {
        //intialization of variable sentences for que of strings
        sentences = new Queue<string>();
    }

    public void StartDialogue(DialogueNPC dialogue)
    {
        //initilaization of variable player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //disables movement of object player
        player.GetComponent<PlayerMovement>().setCanMove(false);
        //moves player to specific position
        //player.transform.position = (player.transform.position - player.transform.position) + triggerer.transform.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //disable cooldown bar visibility
        player.GetComponent<Player_Attack>().setCooldownVisible(false);
        //calling of setIsUp method
        setIsUp(true);
        //sets text
        nameText.text = "Hi " + PlayerPrefs.GetString("nick");
        //clears the sentence
        sentences.Clear();

        //puts all sentences in que in right order Enqueue - first in first out
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //ends dialogue if last sentence has been displayed
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }


        //dequeues sentence in right order
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //method for writing effect
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.15f);
        }
    }

    public void EndDialogue()
    {
        //initialization of player variable
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //turns on player movement
        player.GetComponent<PlayerMovement>().setCanMove(true);
        //turn on cooldown bar visibility
        player.GetComponent<Player_Attack>().setCooldownVisible(true);
        //starts end of dialogue animation
        setIsUp(false);
        //destroys triggerer
        //Destroy(triggerer);
    }

    //method to set value of variable which controlls animation of dialgue
    public void setIsUp(bool status)
    {
        animator.SetBool("IsUp", status);
    }

}

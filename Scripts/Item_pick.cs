using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Item_pick : MonoBehaviour
{
    public Sprite hasCertificate;

    public GameObject[] certificates;

    public int numberOfCertificates;

    private void Start()
    {
        //initializations of UI certificates
        certificates[0] = GameObject.FindGameObjectWithTag("certificate1");
        certificates[1] = GameObject.FindGameObjectWithTag("certificate2");
        certificates[2] = GameObject.FindGameObjectWithTag("certificate3");
        certificates[3] = GameObject.FindGameObjectWithTag("certificate4");

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //condition for heart item
        if (collision.gameObject.CompareTag("heart"))
        {
            //delete object who collided with player
            Destroy(collision.gameObject);
            //current healt + 20 health
            gameObject.GetComponent<Health>().health += 20;
        }

        if (collision.gameObject.CompareTag("certificate"))
        {
            numberOfCertificates++;
            //delete object who collided with player
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("hribItem"))
        {
            //increments variable on collision
            GameObject.FindObjectOfType<DialogueTriggerNPC>().npcItems ++;
            Destroy(collision.gameObject);
        }

    }

    //method which updates certificates in UI
    public void certificateUpdate()
    {
        for (int i = 0; i < numberOfCertificates; i++)
        {
            certificates[i].GetComponent<Image>().sprite = hasCertificate;
        }
    }

    //method which returns number of certificates
    public int getNumberOfCerificates()
    {
        return numberOfCertificates;
    }


}

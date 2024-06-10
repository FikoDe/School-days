using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 0;
    //private int numOfHearts = 5;

    public GameObject[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    public GameObject DeathCanvas;
    //public GameObject UiCanvas;

    [SerializeField]
    private float protectionDuration;

    private SpriteRenderer sprite;


    // public Camera cam;
    public Animator death;
    public bool isDead = false;
    private bool canBeDamaged = true;

    

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();

        //initialization of hearts in UI
        hearts[0] = GameObject.FindGameObjectWithTag("heart1");
        hearts[1] = GameObject.FindGameObjectWithTag("heart2");
        hearts[2] = GameObject.FindGameObjectWithTag("heart3");
        hearts[3] = GameObject.FindGameObjectWithTag("heart4");
        hearts[4] = GameObject.FindGameObjectWithTag("heart5");
    }

    // Update is called once per frame
    void Update()
    {
        HealthChceck();
        HealthUpdate();
        Die();
    }

    public void HealthChceck()
    {
        if(health > 100)
        {
            health = 100;
        }
    }

    //method for health bar update by number of health
    public void HealthUpdate()
    {
        int count = health;
        for (int i = 0; i < hearts.Length; i++)
        {
            if ((health / 20) > i)
            {
                hearts[i].GetComponent<Image>().sprite = fullHeart;
                count -= 20;
            }
            else
            {
                if (count == 10)
                {
                    hearts[i].GetComponent<Image>().sprite = halfHeart;
                    count -= 10;
                }
                else
                {
                    hearts[i].GetComponent<Image>().sprite = emptyHeart;
                }

            }
        }
    }
    //Getter for variable helth
    public int getHealth()
    {
        return health;
    }

    //decreses or increase health when called
    public void GetDamaged(int damage)
    {
        if (health > 0)
        {
            canBeDamaged = false;
            //starts method Hit in the same tame as GetDamged*********
            StartCoroutine(Hit());
            health = getHealth() - damage;
            StartCoroutine(isSave());
        }
             
    }

    private IEnumerator Hit()
    {
        //changes coloe of sprite
        sprite.color = new Color(1, 0, 0, 1);
        //waits for 0.2 seconds
        yield return new WaitForSeconds(0.2f);
        //changes coloe of sprite
        sprite.color = new Color(1, 1, 1, 1);
    }

    //method which allows enemy to hit player just onve per second
    private IEnumerator isSave()
    {
        yield return new WaitForSeconds(protectionDuration);
        canBeDamaged = true;
    }

    //getter for canBeDamaged
    public bool getCanBeDamaged()
    {
        return canBeDamaged;
    }

    
    public void Die()
    {
        isDead = false;
        if (health <= 0)
        {
            isDead = true;
            // set parameter IsDead to triggered to start death animation
            death.SetTrigger("IsDead");
            GetComponent<Player_Attack>().setCooldownVisible(false);
            //if which checks if death animation is over
            if (death.GetCurrentAnimatorStateInfo(0).IsName("death_animation"))
            {
                //turn off continuing of the time
                Time.timeScale = 0f;

                //turns on DeathCanvas
                DeathCanvas.SetActive(true); 
            }
        }
    }  
}




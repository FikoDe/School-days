using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Attack : MonoBehaviour
{
    //declaration of propertys
    private GameObject attackAreaRightSh = default;
    private GameObject attackAreaLeftSh = default;
    private GameObject attackAreaUpSh = default;
    private GameObject attackAreaDownSh = default;
    private GameObject attackAreaRightLn = default;
    private GameObject attackAreaLeftLn = default;
    private GameObject attackAreaUpLn = default;
    private GameObject attackAreaDownLn = default;

    public Animator attack;

    private bool attacking = false;
    private bool canAttack = true;

    private float timeToAttack = 0.8f;
    private float attackDuration = 0.7f;
    private float timer = 0f;
    private bool attackType = false;

    [SerializeField] private Sprite cooldown00;
    [SerializeField] private Sprite cooldown01;
    [SerializeField] private Sprite cooldown02;
    [SerializeField] private Sprite cooldown03;
    [SerializeField] private Sprite cooldown04;
    [SerializeField] private Sprite cooldown05;
    [SerializeField] private Sprite cooldown06;
    [SerializeField] private Sprite cooldown07;
    [SerializeField] private Sprite cooldown08;
    private GameObject cooldown;

    //Start is called before first frame update
    void Start()
    {
        attackAreaRightSh = transform.Find("AttackAreaRightSh").gameObject;
        attackAreaLeftSh = transform.Find("AttackAreaLeftSh").gameObject;
        attackAreaUpSh = transform.Find("AttackAreaUpSh").gameObject;
        attackAreaDownSh = transform.Find("AttackAreaDownSh").gameObject;
        attackAreaRightLn = transform.Find("AttackAreaRightLn").gameObject;
        attackAreaLeftLn = transform.Find("AttackAreaLeftLn").gameObject;
        attackAreaUpLn = transform.Find("AttackAreaUpLn").gameObject;
        attackAreaDownLn = transform.Find("AttackAreaDownLn").gameObject;
        cooldown = GameObject.FindGameObjectWithTag("Cooldown");
    }


    // Update is called once per frame
    void Update()
    {
        //if player can attack the ifs chceck for button player prassed
        if (canAttack)
        {
            if (attackType) { 
                if (Input.GetKeyDown(KeyCode.L))
                {
                    AttackLong(attackAreaRightLn, "Att_Ln_Right");
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    AttackLong(attackAreaLeftLn, "Att_Ln_Left");
                }
                if (Input.GetKeyDown(KeyCode.I))
                {
                    AttackLong(attackAreaUpLn, "Att_Ln_Up");
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    AttackLong(attackAreaDownLn, "Att_Ln_Down");
                }
            }

            if (!attackType)
            {
                if (Input.GetKeyDown(KeyCode.L))
                {
                    AttackShort(attackAreaRightSh, "Att_Sh_Right");
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    AttackShort(attackAreaLeftSh, "Att_Sh_Left");
                }
                if (Input.GetKeyDown(KeyCode.I))
                {
                    AttackShort(attackAreaUpSh, "Att_Sh_Up");
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    AttackShort(attackAreaDownSh, "Att_Sh_Down");
                }
            }
        }

        //if player cant attack this if chceck if enought time has passed since last attack to enable attacking 
        if (!canAttack)
        {
            timer += Time.deltaTime;

            if (timer >= attackDuration)
            {
                //timer = 0;
                attacking = false;
                attackAreaRightSh.SetActive(attacking);
                attackAreaLeftSh.SetActive(attacking);
                attackAreaUpSh.SetActive(attacking);
                attackAreaDownSh.SetActive(attacking);
                attackAreaRightLn.SetActive(attacking);
                attackAreaLeftLn.SetActive(attacking);
                attackAreaUpLn.SetActive(attacking);
                attackAreaDownLn.SetActive(attacking);
                attack.ResetTrigger("Att_Sh_Right");
                attack.ResetTrigger("Att_Sh_Left");
                attack.ResetTrigger("Att_Sh_Down");
                attack.ResetTrigger("Att_Sh_Up");
            }

            if (timer >= timeToAttack)
            {
                timer = 0;
                canAttack = true;
                //cooldown.GetComponent<Image>().sprite = cooldown00;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            changeAttackType();
        }
        

    }


    private void changeAttackType()
    {
        if (attackType)
        {
            attackType = false;
        }
        else
        {
            attackType = true;
        }
//        Debug.Log(attackType);
    }

    //function Attack sets active diffrent hitboxes for attack and play animation
    private void AttackShort(GameObject hitBox, string trigger)
    {
        cooldown.GetComponent<Image>().sprite = cooldown01;
        StartCoroutine(cooldownSetter01());
        attacking = true;
        canAttack = false;
        StartCoroutine(waitForAnimation(hitBox));
        attack.SetTrigger(trigger);
        //Debug.Log("Stlaceny attack");
    }

    private void AttackLong(GameObject hitBox, string trigger)
    {
        cooldown.GetComponent<Image>().sprite = cooldown01;
        StartCoroutine(cooldownSetter01());
        attacking = true;
        canAttack = false;
        StartCoroutine(waitForAnimation(hitBox));
        attack.SetTrigger(trigger);
        //Debug.Log("Stlaceny attack");
    }


    //waits with activating the hitbox to be in sink with animation
    private IEnumerator waitForAnimation(GameObject direction)
    {
        yield return new WaitForSeconds(0.4f);
        direction.SetActive(attacking);
    }

    //start chain reaction of coroutines wich change the sprite on cooldown bar
    private IEnumerator cooldownSetter01()
    {
        yield return new WaitForSeconds(timeToAttack/8);
        StartCoroutine(cooldownSetter02());
        cooldown.GetComponent<Image>().sprite = cooldown02;
    }
    private IEnumerator cooldownSetter02()
    {
        yield return new WaitForSeconds(timeToAttack / 8);
        StartCoroutine(cooldownSetter03());
        cooldown.GetComponent<Image>().sprite = cooldown03;
    }
    private IEnumerator cooldownSetter03()
    {
        yield return new WaitForSeconds(timeToAttack / 8);
        StartCoroutine(cooldownSetter04());
        cooldown.GetComponent<Image>().sprite = cooldown04;
    }
    private IEnumerator cooldownSetter04()
    {
        yield return new WaitForSeconds(timeToAttack / 8);
        StartCoroutine(cooldownSetter05());
        cooldown.GetComponent<Image>().sprite = cooldown05;
    }
    private IEnumerator cooldownSetter05()
    {
        yield return new WaitForSeconds(timeToAttack / 8);
        StartCoroutine(cooldownSetter06());
        cooldown.GetComponent<Image>().sprite = cooldown06;
    }
    private IEnumerator cooldownSetter06()
    {
        yield return new WaitForSeconds(timeToAttack / 8);
        StartCoroutine(cooldownSetter07());
        cooldown.GetComponent<Image>().sprite = cooldown07;
    }
    private IEnumerator cooldownSetter07()
    {
        yield return new WaitForSeconds(timeToAttack / 8);
        StartCoroutine(cooldownSetter08());
        cooldown.GetComponent<Image>().sprite = cooldown08;
    }
    private IEnumerator cooldownSetter08()
    {
        yield return new WaitForSeconds(timeToAttack / 8);
        cooldown.GetComponent<Image>().sprite = cooldown00;
    }
    //end of chain of coroutines

    public void setCooldownVisible(bool value) { 
            cooldown.SetActive(value);
    }
}
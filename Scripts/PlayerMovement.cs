using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;

    public bool canMove = true;

    [SerializeField] private Transform center;
    [SerializeField] private float knockBackValue = 1f;
    [SerializeField] private float knockBackTime = 0.5f;

    private float savedSpeed;

    void Start()
    {
        savedSpeed = moveSpeed;    
    }

    // Update is called once per frame
    void Update()
    {
        //if player is not dead
        if (gameObject.GetComponent<Health>().isDead == false && canMove == true)
        {
            //turns off the cursor visibility
            //Cursor.visible = false;
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            //sets to animator parameters value of positions and speed
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        {
     

            //sets to animator parameters value of positions and speed
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
        }
        

    }

    private void FixedUpdate()
    {
        
        if (gameObject.GetComponent<Health>().isDead == false && canMove == true)
        {
            if (movement.x != 0 && movement.y != 0)
            {
                rb.MovePosition(rb.position + movement * moveSpeed * 0.7f * Time.fixedDeltaTime);
            }
            else
            {
                //calculates next position of player
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            }

        }
        
    }

    public void setCanMove(bool canMove)
    {
        this.canMove = canMove;
    }
    
    //When called calculate new location for player and disable his movement and knock him there
    public void KnockBack(Transform t)
    {
        var dir = transform.position - t.position;
        setCanMove(false);
        rb.velocity =  dir.normalized * knockBackValue;
        StartCoroutine(UnKnockBack());
    }

    //reanable players movement
    private IEnumerator UnKnockBack()
    {
        yield return new WaitForSeconds(knockBackTime);
        setCanMove(true);
    }

    //method for slow
    public void Slow(float duration, float newSpeed)
    {
        moveSpeed = newSpeed;
        StartCoroutine(unSlow(duration));
    }

    //method for unslow
    private IEnumerator unSlow(float duration)
    {
        yield return new WaitForSeconds(duration);
        moveSpeed = savedSpeed;
    }
}

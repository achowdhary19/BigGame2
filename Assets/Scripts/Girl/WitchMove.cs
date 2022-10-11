using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchMove : MonoBehaviour
{

    public static WitchMove Instance;
    public CharacterControl controller;
    public Animator animator; 
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;


    void Awake()
    {
        Instance = this; 
    }
    void Update () {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        
        else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetButtonDown("Fire1")) //z
        {

            animator.SetBool("IsShooting", true);
        }
        
        else if (Input.GetButtonUp("Fire1"))//z
        {

            animator.SetBool("IsShooting", false);
        }
        
        else if (Input.GetButtonDown("Fire2")) //x
        {
            animator.SetBool("IsAttacking", true);
        }
        
        else if (Input.GetButtonUp("Fire2")) //x
        {
            animator.SetBool("IsAttacking", false);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("IsCrouching", true);
        }
		
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("IsCrouching", false);
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    void FixedUpdate ()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
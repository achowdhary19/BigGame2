using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public GameObject attackPos; 
    public float EnemyHealth = 50;
    public static EnemyController Instance; 
    
    
    
    
    
    void Awake()
    {
        Instance = this; 
    }


    void Update()
    {
        if (Arrow.Instance.hit)
        {
            Arrow.Instance.hit = false;
            StartCoroutine(TakeDamage()); 
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Girl")
        {
            if (WitchMove.Instance.animator.GetBool("IsAttacking"))//sword attack 
            {
                StartCoroutine(TakeDamage());
            }
        }
    }

    IEnumerator TakeDamage()
    {
        //Debug.Log(EnemyHealth);
        EnemyMove.Instance.animator.SetBool("IsDamaged", true);
        EnemyHealth -= 10;
        yield return new WaitForSeconds(.5f);
        EnemyMove.Instance.animator.SetBool("IsDamaged", false);
        
        Debug.Log(EnemyHealth);

        if (EnemyHealth <= 0)
        {
            EnemyMove.Instance.animator.SetBool("IsDying", true );
            EnemyMove.Instance.AddComponent<Rigidbody2D>().gravityScale = 1; 

        }
    
    }
}

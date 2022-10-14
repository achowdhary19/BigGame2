using System.Collections;
using System.Collections.Generic;
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
        /*if (EnemyHealth == 0)
        {
            EnemyMove.Instance.animator.SetBool("IsDying", true);   
        }*/
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Girl")
        {
            if (WitchMove.Instance.animator.GetBool("IsAttacking"))
            {
                StartCoroutine(TakeDamage());
            }
        }
    }

    IEnumerator TakeDamage()
    {
        
        EnemyMove.Instance.animator.SetBool("IsDamaged", true);
        //EnemyHealth -= 10;
        yield return new WaitForSeconds(2f);
        EnemyMove.Instance.animator.SetBool("IsDamaged", false);
    }
    
   
    
    
    
}

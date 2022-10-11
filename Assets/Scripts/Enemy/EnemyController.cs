using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float EnemyHealth = 50; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (WitchMove.Instance.animator.GetBool("IsAttacking"))
        {
            StartCoroutine(TakeDamage());
        }*/

        if (EnemyHealth == 0)
        {
            EnemyMove.Instance.animator.SetBool("IsDying", true);   
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Girl" )
            //&& WitchMove.Instance.animator.GetBool("IsAttacking")
        {
            StartCoroutine(TakeDamage());
            //collision.gameObject.SendMessage("ApplyDamage", 10);
            EnemyHealth -= 10; 
            Debug.Log(EnemyHealth);
        }
    }

    IEnumerator TakeDamage()
    {
        EnemyMove.Instance.animator.SetBool("IsDamaged", true);
        yield return new WaitForSeconds(2f);
        EnemyMove.Instance.animator.SetBool("IsDamaged", false);
    }
    
    
    
}

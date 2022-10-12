using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public static EnemyMove Instance;
    public Animator animator;
    public Transform Girl;
    [SerializeField] public LayerMask LayerMask; 
    void Awake()
    {
        Instance = this; 
    }

    private void Start()
    {
        StartCoroutine(EnemyIdle());
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Girl.position-transform.position, 5, LayerMask);
        //out hit is what i hit and how far away it is 
       
        if (hit.collider != null && hit.collider.tag == "Girl")
        {
            animator.SetBool("CanWeSeePlayer", true);
        }
        else
        {
            animator.SetBool("CanWeSeePlayer",false);
        }
        
       
        float distance = Vector3.Distance(Instance.transform.position, Girl.position);

        animator.SetFloat("Distance", distance);
    }
    
    
    IEnumerator EnemyIdle()
    {
        while (true)
        {
            //false, not idling just flying 
            bool state = animator.GetBool("EnemyIdle");
            animator.SetBool("EnemyIdle", state);
            
            //true, idling not flying
            yield return new WaitForSeconds(2f);
            state = !state;
            animator.SetBool("EnemyIdle", state);
        }
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue; 
        Gizmos.DrawLine(transform.position, Girl.position); 
        Gizmos.color = Color.white;
        //Gizmos.DrawLine(transform.position,transform.position+transform.forward* 5f);
    }
    
}

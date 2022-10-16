using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour
{
    public static EnemyMove Instance;
    public Animator animator;
    public Transform Girl;
    [SerializeField] public LayerMask LayerMask; 
    
    
    private float MaxWaitTime = 2f;

    [SerializeField] private float RandomPositionXRange = 3.5f;
    [SerializeField] private float RandomPositionYRange = .5f;
    public float speed = 1f;


    void Awake()
    {
        Instance = this; 
    }

    private void Start()
    {
        StartCoroutine(EnemyIdle());
        //StartCoroutine(BirdRandomMove());
    }


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
    
    
    IEnumerator BirdRandomMove()
    {
        while (true)
        {
            bool state = animator.GetBool("EnemyIdle");
            animator.SetBool("EnemyIdle", state);
            yield return new WaitForSeconds(Random.value * MaxWaitTime);
            Vector3 localTarget;
            localTarget.x = (Random.value * 2 - 1) * RandomPositionXRange;
            localTarget.y = (Random.value * 2 - 1) * RandomPositionYRange;
            Vector3 randomTarget = new Vector3(localTarget.x, localTarget.y); 
            Vector3 targetPosition = Instance.transform.position + randomTarget;
            yield return new WaitForSeconds(1f);
            state = !state;
            animator.SetBool("EnemyIdle", state);
            
            while (Instance.transform.position != targetPosition)
            {
                yield return null;
                Instance.transform.position = Vector3.MoveTowards(Instance.transform.position, targetPosition, speed * Time.deltaTime);
            }
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

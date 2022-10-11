using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        
    }
    
    public float multiplier = 1f;
    public float direction = 1; 
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private float MaxWaitTime = 2f;

    [SerializeField] private float RandomPositionXRange = 3.5f;
    [SerializeField] private float RandomPositionYRange = .5f;


        

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (EnemyMove.Instance.transform.position.x >= 3.25) //theres got to be a better way to do this 
        {
            Flip();
            direction = -1;
        }
     
        else if (EnemyMove.Instance.transform.position.x <= .4)
        {
            Flip();
            direction = 1;
        }
        EnemyMove.Instance.transform.position += new Vector3(1f, 0) * Time.deltaTime * multiplier * direction;
        
    }


    /*public IEnumerator Bird()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.value * MaxWaitTime);
            Vector3 localTarget;
            localTarget.x = (Random.value * 2 - 1) * RandomPositionXRange;
            localTarget.y = (Random.value * 2 - 1) * RandomPositionYRange;
            Vector3 targetPosition = EnemyMove.Instance.transform.position + localTarget;
            
            while (EnemyMove.Instance.transform.position != targetPosition)
            {
                yield return null;
                EnemyMove.Instance.transform.position = Vector3.MoveTowards(EnemyMove.Instance.transform.position, targetPosition, multiplier * Time.deltaTime);
            }
        }
    }*/

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = EnemyMove.Instance.transform.localScale;
        theScale.x *= -1;
        EnemyMove.Instance.transform.localScale = theScale;
    }
    
    
    
    

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

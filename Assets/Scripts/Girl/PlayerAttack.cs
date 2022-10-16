using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform arrowPos;
    [SerializeField] private GameObject arrow;
    [SerializeField] private float velocity; 
    
    public void Attack()
    {
        GameObject firedArrow = Instantiate(arrow, arrowPos.position, Quaternion.identity);
        firedArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, 0);
        Destroy(firedArrow,7);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using JetBrains.Annotations;
using Mono.Cecil;
using UnityEngine;
using Random=UnityEngine.Random;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float Speed;
    public static Arrow Instance;

    private void Awake()
    {
        Instance = this; 
    }
    private void Start()
    {
        if (WitchMove.Instance.animator.GetBool("IsShooting"))
        {
            Fire();   
        }

    }

    private void Fire()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * Speed; //do i want this initial pos to be random and initial direction? 
    }

    
    void Update()
    {
      
        if (gameObject.transform.position.x < -14) 
        {
            Destroy(gameObject);
        }
        
        if (gameObject.transform.position.x > 20) 
        {
            Destroy(gameObject);
        }
    }
   
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.gameObject.name == "Enemy" || col.transform.gameObject.name == "background")
        {
            Destroy(gameObject); //destroying the game object attached to script, not the class game object 

        }
    }
   
}
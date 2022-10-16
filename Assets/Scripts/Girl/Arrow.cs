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
    public static Arrow Instance;

    public bool hit = false; 

    private void Awake()
    {
        Instance = this; 
    }
    private void Start()
    {
       

    }
    
    void Update()
    {
    }
   
    private void OnCollisionEnter2D(Collision2D col)
    {
        if ( col.transform.gameObject.tag == "environment")
        {
            Destroy(gameObject); //destroying the game object attached to script, not the class game object 
            Debug.Log("arrow just hit environment ");
        }

        if (col.transform.gameObject.name == "Enemy")
        {
            Destroy(gameObject); //destroying the game object attached to script, not the class game object 
            hit = true; 
            Debug.Log("arrow just hit enemy  ");
            
        }
    }
   
}
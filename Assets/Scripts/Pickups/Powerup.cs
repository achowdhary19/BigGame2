using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject pickupEffect;
    public PowerupEffect PowerupEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.CompareTag("Girl"))
        {
            StartCoroutine(Pickup(other));
        }*/

        if (other.CompareTag("Girl"))
        {
            Destroy(gameObject);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            PowerupEffect.Apply(other.gameObject);
        }
    }

 /*IEnumerator Pickup(Collider2D player)
   {
       Instantiate(pickupEffect, transform.position, transform.rotation);
       player.transform.localScale *= multiplier;
       
       //so that we can't interact / see it when we get it. 
       GetComponent<Collider2D>().enabled = false;
       GetComponent<SpriteRenderer>().enabled = false; 
       
       yield return new WaitForSeconds(duration); 
       player.transform.localScale /= multiplier;
       
       //only destroy it after everything is done 
       Destroy(gameObject); 
       
   }*/
    
    
    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Powerups/Grow")]
public class GrowPowerup : PowerupEffect
{
   public float multiplier;
   // public GameObject pickupEffect;
    //public float duration = 3f; 
   
    
    public override void Apply(GameObject player)
   {
       //overrriding this method from our parent powerup effect class 
       player.transform.localScale *= multiplier;
   }
   
   
   
   /*IEnumerator Pickup(Collider2D player)
  {
      Instantiate(pickupEffect, player.transform.position, player.transform.rotation);
      player.transform.localScale *= multiplier;
      
      //so that we can't interact / see it when we get it. 
      //GetComponent<Collider2D>().enabled = false;
      //GetComponent<SpriteRenderer>().enabled = false; 
      
      yield return new WaitForSeconds(duration); 
      player.transform.localScale /= multiplier;
      
      //only destroy it after everything is done 
      Destroy(gameObject); 
      
  }*/
   
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerupEffect
{
    public float amount;

    public override void Apply(GameObject player)
    {
        //overrriding this method from our parent powerup effect class 
        player.GetComponent<PlayerStats>().health += amount;
    }
}
  

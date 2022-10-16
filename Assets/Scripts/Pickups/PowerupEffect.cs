using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupEffect : ScriptableObject
{
    /*abstract means we can never initialize or make an intstance of this powerupeffect class, 
    but we cna inherit from it! */
    
    //template of what we want our scriptable objects to be
    public abstract void Apply(GameObject player);   
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float damageDone;
    public Pawn owner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onTriggerEvent (Collider other)
    {
        //Get the Health component from the Game Object that has the collision
        Health otherHealth = other.GetComponent<Health>();
        
        //only damage if it has a health
        if(otherHealth != null) 
        {
            //do damage
            otherHealth.takeDamage(damageDone, owner);
        }

        //destroy ourseleves, wether we did damage or not
        Destroy(gameObject);
    }
}

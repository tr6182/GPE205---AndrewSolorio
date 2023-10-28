using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    public Transform firepointTransform;
    public override void Start ()
    {

    }
    public override void Update ()
    {

    }
    public override void Shoot(GameObject shellPrefab, float fireforce, float damageDone, float lifeSpan)
    {
        // instantiate our projectile
        GameObject newShell = Instantiate(shellPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;
        
        // get DamageOnHit component
        DamageOnHit doh = newShell.GetComponent<DamageOnHit>();

        //if it has a DamageOnHit component
        if (doh != null )
        {
            // ... set the damageDone in the DamageOnHit component to the value passed in
            doh.damageDone = damageDone;
            // ... set the owner to the pawn that shot this shell, if there is one (otherwise, owner is null)
            doh.owner = GetComponent<Pawn>();
        }
        // get the shell's rigidbody component
        Rigidbody rb = newShell.GetComponent<Rigidbody>();
        // if it has a rigidbody
        if (rb != null)
        {
            // ...AddForce to make it move forward
            rb.AddForce(firepointTransform.forward * fireforce);

        }
        // destroy it after a set time
        Destroy(newShell, lifeSpan);

    }
}

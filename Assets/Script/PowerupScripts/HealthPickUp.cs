using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public HealthPowerup powerup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // variable to store other object's powerupController - if it has one
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        // if the other oject has PowerupManager 
        if (powerupManager != null)
        {
            // add the powerup
            powerupManager.Add(powerup);
            // destroy this pickup
            Destroy(gameObject);
        }
    }
}

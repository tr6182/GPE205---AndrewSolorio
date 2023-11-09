using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;
    private List<Powerup> removedPowerupQueue;
    // Start is called before the first frame update
    void Start()
    {
        powerups = new List<Powerup>();
        // added new list
        removedPowerupQueue = new List<Powerup>();
    }

    // Update is called once per frame
    void Update()
    {
        DecrementPowerupTimers();
    }

    private void LateUpdate()
    {
        ApplyRemovePowerupsQueue();
    }

    // the add function will eventually add a powerup
    public void Add(Powerup powerupToAdd)
    {
        // TODO: Create the Add() Method
        powerupToAdd.Apply(this);
        // save it to the list
        powerups.Add(powerupToAdd);
    }

    // the remove function will eventually remove a powerup
    public void Remove(Powerup powerupToRemove)
    {
        // TODO : Create the Remove() Method
        powerupToRemove.Remove(this);
        // add it to the "to be removed queue"
        removedPowerupQueue.Add(powerupToRemove);
    }

    public void DecrementPowerupTimers()
    {
        // one-at-a-time, put each object in "powerups" into the variable "powerup" and do the loop body on it
        foreach(Powerup powerup in powerups)
        {
            if(powerup.isPermanent)
            {
                // subtract the time it took to draw the frame the duration
                powerup.duration -= Time.deltaTime;
                // if time is up, we want to remove this powerup
                if (powerup.duration <= 0)
                {
                    Remove(powerup);
                }
            }
        
        }
    }

    private void ApplyRemovePowerupsQueue()
    {
        // now that we are sure we are not iteration through "powerups", remove the powerups that are in our temporary
        foreach(Powerup powerup in removedPowerupQueue)
        {
            powerups.Remove(powerup);
        }
        // and reset our temporary list
        removedPowerupQueue.Clear();
    }
}

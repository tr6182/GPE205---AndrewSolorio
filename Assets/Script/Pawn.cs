using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    // variable for move speed
    public float moveSpeed;
    // variable for turn speed
    public float turnSpeed;
    //variable for rate of fire
    public float fireRate;
    // variable for our shell prefab
    public GameObject shellPrefab;
    // variable for our firing force
    public float fireforce;
    // variable for our damage done
    public float damageDone;
    // variable for bullet lifespan if it doesn't collide
    public float shellLifespan;
    // variable to hold our mover
    public Mover mover;
    // variable to hold our shooter
    public Shooter shooter;
    // variable to hold out Noisemaker
    public NoiseMaker noiseMaker;
    // variable for the volume of our noisemaker
    public float noiseMakerVolume;
    public virtual void Start()
    {
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
        noiseMaker = GetComponent<NoiseMaker>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
    public abstract void Shoot();
    public abstract void RotateTowards(Vector3 targetPostion);
    public abstract void MakeNoise();
    public abstract void StopNoise();
}

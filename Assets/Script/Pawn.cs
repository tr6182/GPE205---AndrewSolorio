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
    // variable to hold our mover
    public Mover mover;
    public virtual void Start()
    {
        mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
}

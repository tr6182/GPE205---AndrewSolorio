using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Start();
    }

    public override void MoveForward() 
    {
        if (mover != null) 
        {
            mover.Move(transform.forward, moveSpeed);
        } else
        {
            Debug.LogWarning("Warning: no mover in TankPawn.Moverforward()!");
        }
    }
    public override void MoveBackward()
    { if (mover != null)
 
    
        {
            mover.Move(transform.forward, -moveSpeed);
        }      else 
        {
            Debug.LogWarning("Warning : no mover in TankPawn.Moverbackwards()!");
        }
    }
    public override void RotateClockwise()
    { if (mover != null) 
        
    
        {
            mover.Rotate(turnSpeed);
        }else 
        {
            Debug.LogWarning("Warning : no mover in TankPawn.RotateClockwise");
        } 
    }
    public override void RotateCounterClockwise()
    { if (mover != null)
    
        {
            mover.Rotate(-turnSpeed);
        } else
        {
            Debug.LogWarning("Warning : no mover in TankPawn.RotateCounterClockwise");
        }
    }


    public override void Shoot()
    {
        shooter.Shoot(shellPrefab, fireforce, damageDone, shellLifespan);
    }

    public override void RotateTowards(Vector3 targetPostion)
    {
        // find the vector to our target
        Vector3 vectorToTarget = targetPostion - transform.position;
        // find the rotation to look down the vector 
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        // rotate closer to that vector, but don't rotate more than our turn soeed allows in one frame
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
    public override void MakeNoise()
    {
        if(noiseMaker!= null)
        {
            noiseMaker.volumeDistance = noiseMakerVolume;
        }
    }
    public override void StopNoise()
    {
        if(noiseMaker != null)
        {
            noiseMaker.volumeDistance = 0;
        }
    }
}

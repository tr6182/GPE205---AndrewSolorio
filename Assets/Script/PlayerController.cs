using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
[System.Serializable]
public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
<<<<<<< HEAD
=======
    public KeyCode shootKey;
>>>>>>> main
    // Start is called before the first frame update
   public override void Start()
    {
        // if we have a GameManger
        if (GameManager.instance != null)
        {
            // and it tracks the player
            if (GameManager.instance.players != null)
            {
                // registar with the GameManager
                GameManager.instance.players.Add(this);

            } 
        }
        // run the Start() function from the parent (base) class
        base.Start();
    }

    // Update is called once per frame
   public override void Update()
    {
        // process our keyboard inputs
        ProcessInputs(); 

        //run the update() function from the parent (base)
        base.Update();
    }

    public override void ProcessInputs()
    {
        if(Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
<<<<<<< HEAD
=======
            pawn.MakeNoise();
>>>>>>> main
        }
        if(Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
<<<<<<< HEAD
=======
            pawn.MakeNoise();
>>>>>>> main
        }
        if(Input.GetKey(rotateClockwiseKey)) 
        {
            pawn.RotateClockwise();
<<<<<<< HEAD
=======
            pawn.MakeNoise();
>>>>>>> main
        }
        if(Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
<<<<<<< HEAD
=======
            pawn.MakeNoise();
        }
        if (Input.GetKeyDown (shootKey)) 
        {
            pawn.Shoot();
            pawn.MakeNoise();
        }
        if (!Input.GetKeyDown (moveForwardKey) && !Input.GetKeyDown (moveBackwardKey) && !Input.GetKeyDown(rotateClockwiseKey) && !Input.GetKeyDown(rotateCounterClockwiseKey) && !Input.GetKeyDown(shootKey))
        {
            pawn.StopNoise();
>>>>>>> main
        }
        
    }

    public void OnDestroy()
    {
        // if we have a GameManager
        if (GameManager.instance != null)
        {
            // and tracks player(s)
            // DeRegister with the GameManager
            GameManager.instance.players.Remove(this);
        }
    }
}

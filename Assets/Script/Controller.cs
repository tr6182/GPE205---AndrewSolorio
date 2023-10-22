using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    // variable to hold our pawn
    public Pawn pawn;
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    // our child classes MUST override the way they process inputs
    public abstract void ProcessInputs();
}

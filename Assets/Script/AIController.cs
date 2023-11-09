using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AIController : Controller
{
    public enum AIState { Guard, Chase, Attack, Patrol };
    public AIState currentState;
    private float lastStateChangeTime;
    public GameObject target;

    public Transform[] waypoints;
    public float waypointStopDistance;

    public float hearingDistance;

    public float fieldOfView;

    private int currentWaypoint = 0;

    // Start is called before the first frame update
   public override void Start()
    {
        ChangeState (AIState.Patrol);
        //ChangeState(AIState.Patrol);
        // run the parent (base) start
        base.Start();
    }

    // Update is called once per frame
   public override void Update()
    {
        // make decisions
        ProcessInputs();
        // run the parent (base) update
        base .Update();
    }
    //going to be responible for making AI decisions
    public override void ProcessInputs()
    {
        Debug.Log("Making Decisions");
        switch (currentState)
        {
          case AIState.Guard:
          // do work for guard
          DoGuardState();
                // check for transtions
                if (IsDistanceLessThan(target, 10))
                {
                ChangeState(AIState.Chase);
                }
                //IsCanSee(target);
                break;
          case AIState.Chase:
                // do work for chase
                if (IsHasTarget())
                {
                    DoChaseState();
                }
                else
                {
                    TargetPlayerOne();
                }
                //check for transitions
                if (IsDistanceLessThan (target, 7))
                {
                    ChangeState(AIState.Attack);
                }
                if(!IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIState.Guard);
                }
                break;
            case AIState.Attack:
                // do work for attack
                DoAttackState();
                // check for transtions
                if(!IsDistanceLessThan(target, 7))
                {
                    ChangeState(AIState.Chase);
                }
                break;
            case AIState.Patrol:
                // do work for patrol
                DoPatrolState();
                // check for transitions

                break;
               
        }
    }

    // patrol state
    protected virtual void DoPatrolState()
    {
        // if we have enough waypoints in out list to moce to a current waypoint
        if(waypoints.Length > currentWaypoint)
        {
            // then seek that waypoint
            Seek(waypoints[currentWaypoint]);
            // if we are close enough, then increment to the next waypoint
            if(Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) < waypointStopDistance)
            {
                currentWaypoint++;
            }
            else
            {
                RestartPartrol();
            }
        }
    }

    protected void RestartPartrol()
    {
        // set the index to 0 
        currentWaypoint = 0;    
    }

    protected void DoGuardState()
    {
        // doing guard state
        Debug.Log("guarding");
    }

    // chase state and behaviors

    protected void DoChaseState()
    {
        // doing chase state
        Debug.Log("Chasing");
        Seek(target);
    }

    public void Seek (GameObject target)
    {
        // rotate towards target
        pawn.RotateTowards(target.transform.position);
        // move forward toward the target
        pawn.MoveForward();
    }
    public void Seek(Transform targetTranform)
    {
        // seek the position of our target transform
        Seek(targetTranform.gameObject);
    }

    // attack state and behaviors

    public void DoAttackState()
    {
        //c hase
        Seek(target);
        // shoot at us
        shoot();
    }

    public void shoot()
    {
        pawn.Shoot();
    }

    // helper functions

    protected bool IsDistanceLessThan (GameObject target, float Distance)
    {
        if (Vector3.Distance (pawn.transform.position, target.transform.position) < Distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void ChangeState(AIState newstate) 
    {
        // change the current state
        currentState = newstate;
        // save the time when we changed states
        lastStateChangeTime = Time.time;
    }

    public void TargetPlayerOne()
    {
        //if the gamemanager exists
        if(GameManager.instance != null) 
        {
            // and there are players in it 
            if (GameManager.instance.players.Count > 0)
            {
                // then target the gameObject of the pawn of the first player controller in the list
                target = GameManager.instance.players[0].pawn.gameObject;
            }
        }

    }
    protected bool IsHasTarget()
    {
        // return true if we have a target, false if we don't
        return(target != null);
    }

    protected bool IsCanHear(GameObject target)
    {
        // get the target's noisemaker
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();
        // if they don't have a noiseMaker it will return false
        if (noiseMaker == null)
        {
            return false;
        }
        // if they are making 0 noise, they also can't be heard (return false)
        if (noiseMaker.volumeDistance <= 0)
        {
            return false;
        }
        // if they are making noise, add the volumeDistance in the the noiseMaker to the nearingDistance of this AI
        float totalDistance = noiseMaker.volumeDistance + hearingDistance;
        // if the distance between our pawn and target is closer than this ...
        if(Vector3.Distance(pawn.transform.position, target.transform.position) < totalDistance)
        {
            // than we can hear the target
            return true;
        }
        else
        {
            // otherwise, we are to far away to hear them
            return false;
        }
    }

    protected bool IsCanSee(GameObject target)
    {
        // find the vector from the agent to the target
        Vector3 agentToTargetVector = target.transform.position - pawn.transform.position;
        //find the angle between the direction our agent is facing (forward in local space) and the vector to the target
        float angleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.forward);
        Debug.Log(angleToTarget);
        // if that angle is less than our field of view 
        if (angleToTarget < fieldOfView)
        {
            Debug.Log("in field of view");
            return true;
        }
        else
        {
            return false;
        }
    }
}

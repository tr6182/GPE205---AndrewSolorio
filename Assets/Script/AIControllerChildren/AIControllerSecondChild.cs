using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControllerSecondChild : AIController
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        ProcessInputs();
    }

    public override void ProcessInputs()
    {
        //Debug.Log("Making Decisions");
        switch (currentState)
        {
            case AIState.Guard:
                // do work for guard
                base.DoGuardState();
                // check for transitions 
                if (IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIState.Chase);
                }
                IsCanSee(target);
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
                if (IsDistanceLessThan(target, 7))
                {
                    ChangeState(AIState.Attack);
                }
                if (!IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIState.Guard);
                }
                break;
            case AIState.Attack:
                // do work for attack
                base.DoAttackState();
                // check for transtions
                if (!IsDistanceLessThan(target, 7))
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
    protected override void DoPatrolState()
    {
        Debug.Log("AIController Child Implementation of Do Patrol State");
    }


}
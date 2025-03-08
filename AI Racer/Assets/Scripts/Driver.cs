using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : Kinematic
{
    ObstacleAvoidance myMoveType;
    LookWhereGoing myRotateType;
    public GameManager myGameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new ObstacleAvoidance();
        myMoveType.character = this;
        myMoveType.target = myTarget;
        myMoveType.flee = false;

        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        if (myGameManager.gameOver)
        {
            steeringUpdate.linear = Vector3.zero;
            steeringUpdate.angular = 0f;
            return;
        }
        
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.linear.y = 0f;
        steeringUpdate.angular = myRotateType.getSteering().angular;
        base.Update();
    }
}

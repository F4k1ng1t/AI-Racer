using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowder : Kinematic
{
    Arrive myMoveType;
    public GameManager myGameManager;
    int runOnce = 0;
    bool inRadius = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Initialize()
    {
        myMoveType = new Arrive();
        myMoveType.character = this;

    }
    void Crowd()
    {
        if (runOnce != 0)
            return;
        Initialize();
        myMoveType.target = myGameManager.winner;

    }
    // Update is called once per frame
    protected override void Update()
    {
        if (myGameManager.gameOver)
        {
            Crowd();
            if (!inRadius)
            {
                steeringUpdate = new SteeringOutput();
                steeringUpdate.linear = myMoveType.getSteering().linear;
                base.Update();
            }
            else
            {
                steeringUpdate.linear = Vector3.zero;
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!myGameManager.gameOver)
            return;
        if (other.tag == myGameManager.winner.tag)
        {
            inRadius = true;
        }
    }
}

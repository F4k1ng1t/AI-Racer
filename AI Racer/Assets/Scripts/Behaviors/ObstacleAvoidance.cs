using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : Seek
{
    float avoidDistance = 4f;
    float lookahead = 5f;
    

    protected override Vector3 getTargetPosition()
    {
        RaycastHit hit;
        Debug.DrawRay(character.transform.position, character.linearVelocity, Color.red);
        if (Physics.Raycast(character.transform.position, character.linearVelocity, out hit, lookahead))
        {
            Debug.DrawRay(character.transform.position, character.linearVelocity, Color.red);
            return hit.point + (hit.normal * avoidDistance);
        }
        else
        {
            return base.getTargetPosition();
        }

    }

}
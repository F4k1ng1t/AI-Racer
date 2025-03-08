using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [NonSerialized]
    public GameObject winner;
    public bool gameOver = false;
    GameObject finish;

    public float detectionRadius = 10f;
    public Transform[] targets; // Assign objects to check
    [SerializeField]
    private HashSet<Transform> detectedObjects = new HashSet<Transform>();
    //[SerializeField]
    //private LayerMask _obstacleLayer;
    //public static LayerMask obstacleLayer;

    void Start()
    {
        finish = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Workaround for Obstacle Avoidance being unable to enter trigger colliders
        foreach (Transform target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            bool isInside = distance <= detectionRadius;

            if (isInside && !detectedObjects.Contains(target))
            {
                // Object just entered the detection radius
                detectedObjects.Add(target);
                Debug.Log("Entered: " + target.name);
                winner = target.gameObject;
                gameOver = true;
            }
        }
    }
    //ObstacleAvoider cannot enter trigger colliders

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        gameOver = true;
    //        winner = other.gameObject;
    //        Debug.Log($"{other.gameObject.name} wins");
    //    }

    //}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

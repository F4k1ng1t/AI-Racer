using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDriver : MonoBehaviour
{
    LookWhereGoing myRotateType;
    public GameManager myGameManager;
    Rigidbody rb;
    public float speed = 10f;
    public float handling = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (myGameManager.gameOver)
        {
            rb.velocity = Vector3.zero;
            return;
        }
            
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * handling, 0, 0);
            return;
        }
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * handling, 0, speed);
        
    }
}

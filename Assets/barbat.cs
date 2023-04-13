using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barbat : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animate;
    public float jumpSpeed = 5;
    public float moveForce = 10;
    public float maxMoveSpeed = 3;

    private bool isMoving = false;

    private const int MoveLeft = 0;
    private const int MoveRight = 1;
    private const int Jump = 2;
    private bool[] actions = { false, false, false };


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        animate.SetFloat("horizontal", Input.GetAxis("Horizontal"));

        actions[MoveLeft]  = (actions[MoveLeft]  || Input.GetKeyDown(KeyCode.A)) && !Input.GetKeyUp(KeyCode.A);
        actions[MoveRight] = (actions[MoveRight] || Input.GetKeyDown(KeyCode.D)) && !Input.GetKeyUp(KeyCode.D);
        actions[Jump]      =  actions[Jump]      || Input.GetKeyDown(KeyCode.W);
    }

    void FixedUpdate()
    {
        if (actions[MoveLeft])  { rb.AddForce(new Vector2(-moveForce * 10, 0)); }
        if (actions[MoveRight]) { rb.AddForce(new Vector2(moveForce * 10, 0)); }

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxMoveSpeed, maxMoveSpeed), rb.velocity.y);


        if (actions[Jump])
        {
            actions[Jump] = false;

            if (!isMoving)
            {
                // the cube is going to move upwards in 10 units per second
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                isMoving = true;
                Debug.Log("jump");
            }
        }

        if (rb.velocity.y == 0)
        {
            isMoving = false;
        }
    }
}

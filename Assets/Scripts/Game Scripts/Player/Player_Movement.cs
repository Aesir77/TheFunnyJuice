using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    [SerializeField] private float movementSpeed, playerHeight, groundDrag;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float horizontal, vertical;
    [SerializeField] private Vector3 direction, speed;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask ground;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 20f;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        #region movement
        rb.freezeRotation = true;
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Move();
        #endregion

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * (0.6f + 0.2f), ground);
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
        SpeedLimit();
    }

    private void Move()
    {

        direction = player.forward * vertical + player.right * horizontal;
        rb.AddForce(direction.normalized * movementSpeed, ForceMode.Force);
    }

    private void SpeedLimit()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > movementSpeed)
        {
            Vector3 Limit = flatVel.normalized * movementSpeed;
            rb.velocity = new Vector3(Limit.x, rb.velocity.y, Limit.z);
        }
    }
}


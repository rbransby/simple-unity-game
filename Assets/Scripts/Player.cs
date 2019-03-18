using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerBody;    
    private Vector3 inputVector;
    private bool jump;
    
    // Start is called before the first frame update
    void Start()
    {
        this.playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {        
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * 10, playerBody.velocity.y, Input.GetAxisRaw("Vertical") * 10);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        playerBody.velocity = inputVector;
        if (jump && IsGrounded())
        {
            playerBody.AddForce(Vector3.up * 20f, ForceMode.Impulse);
            jump = false;
        }
    }

    private bool IsGrounded()
    {
        float distance = GetComponent<Collider>().bounds.extents.y + 0.01f;
        var ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray, distance);
    }
}

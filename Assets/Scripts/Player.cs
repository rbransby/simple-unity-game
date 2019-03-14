﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerBody;    
    private Vector3 inputVector;
    
    // Start is called before the first frame update
    void Start()
    {
        this.playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {        
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * 10, 0, Input.GetAxisRaw("Vertical") * 10);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));        
    }

    private void FixedUpdate()
    {
        playerBody.velocity = inputVector;
    }
}

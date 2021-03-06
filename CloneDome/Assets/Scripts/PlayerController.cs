﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

//The name of the script and where the script gets its information from.
public class PlayerController : MonoBehaviour
{
    //Calls rigidbody and makes it rigidbody.
    public Rigidbody rigidBody;
    //Calls the xbox controller and makes it the controller.
    public XboxController controller;
    //Sets the variable movement speed.
    public float movementSpeed = 60;
    //Sets the variable max speed.
    public float maxSpeed = 5;
    //Sets the base rotation direction.
    public Vector3 previousRotationDirection = Vector3.forward;

    // Start ()
    // Called on intialization
    // Return:
    //     Void
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // FixedUpdate ()
    // Called on every fixed frame.
    // Return:
    //     Void
    private void FixedUpdate()
    {
        MovePlayer();
    }

    // MovePlayer ()
    // Called whenever MovePlayer is called.
    // Return:
    //     Void
    private void MovePlayer()
    {
        float axisX = XCI.GetAxis(XboxAxis.LeftStickX, controller);
        float axisZ = XCI.GetAxis(XboxAxis.LeftStickY, controller);

        Vector3 movement = new Vector3(axisX, 0, axisZ);

        rigidBody.AddForce(movement * movementSpeed);

        if (rigidBody.velocity.magnitude > maxSpeed)
        {
            rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
        }
    }
    // Update ()
    // Called on every frame.
    // Return:
    //     Void
    private void Update()
    {
        RotatePlayer();
    }
    // RotatePlayer ()
    // Called whenever RotatePlayer is called.
    // Return:
    //     Void
    private void RotatePlayer()
    {
        float rotateAxisX = XCI.GetAxis(XboxAxis.LeftStickX, controller);
        float rotateAxisZ = XCI.GetAxis(XboxAxis.LeftStickY, controller);

        Vector3 directionVector = new Vector3(rotateAxisX, 0, rotateAxisZ);

        if (directionVector.magnitude <0.1f)
        {
            directionVector = previousRotationDirection;
        }

        directionVector = directionVector.normalized;
        previousRotationDirection = directionVector;
        transform.rotation = Quaternion.LookRotation(directionVector);
    }
}


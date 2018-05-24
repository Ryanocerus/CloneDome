using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rigidBody;
    public XboxController controller;

    public float movementSpeed = 60;
    public float maxSpeed = 5;

    public Vector3 previousRotationDirection = Vector3.forward;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float axisX = XCI.GetAxis(XboxAxis.LeftStickX, controller);
        float axisZ = XCI.GetAxis(XboxAxis.LeftStickY, controller);

        Vector3 movement = new Vector3(axisX, 0, axisZ);

        rigidBody.AddForce(movement * movementSpeed);

        //Ensure the player can't go faster the the max speed
        if (rigidBody.velocity.magnitude > maxSpeed)
        {
            rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
        }
    }

    private void Update()
    {
        RotatePlayer();
    }
     
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


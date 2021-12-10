using System;
using System.Collections;
using System.Collections.Generic;
using Root.General;
using Root.MainMenu.Scripts.Controls;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformController : ControlledEntity
{
    [SerializeField] private PlatformerAttributes platformerAttributes;

    private Rigidbody rb;
    private float squaredMaxVelocity;

    private Quaternion rot;

    private Transform mainCamera;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        squaredMaxVelocity = platformerAttributes.movementSpeed * platformerAttributes.movementSpeed;
        mainCamera = Camera.main.transform;
    }
    
    void FixedUpdate()
    {
        Quaternion rot = Quaternion.Euler(0, mainCamera.rotation.eulerAngles.y, 0);
        
        ApplyAccelerationForce();
        ApplyTurningForce();
    }

    private void ApplyAccelerationForce()
    {
        int horizontal = (ConnectedController.left == Controller.ButtonState.Holding ? -1 : 0) + (ConnectedController.right == Controller.ButtonState.Holding ? 1: 0);
        int vertical = (ConnectedController.down == Controller.ButtonState.Holding ? -1 : 0) + (ConnectedController.up == Controller.ButtonState.Holding ? 1: 0);

        Vector3 acceleration = new Vector3(horizontal, 0, vertical) * platformerAttributes.accelerationSpeed;

        rb.AddForce(rot * acceleration, ForceMode.Acceleration);

        if (rb.velocity.sqrMagnitude > squaredMaxVelocity)
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, platformerAttributes.movementSpeed);
    }
    
    private void ApplyTurningForce()
    {
        Vector3 turnVector = rb.velocity;
        turnVector.y = 0;
        turnVector.Normalize();
      
        if (turnVector.sqrMagnitude == 0) return;

        Quaternion newRotation =
            Quaternion.RotateTowards(rb.rotation,
                Quaternion.LookRotation(turnVector, Vector3.up),
                platformerAttributes.turnSpeed);
        rb.MoveRotation(newRotation);
    }
}

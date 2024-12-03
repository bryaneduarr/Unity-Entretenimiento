using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;

    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    private float moveSpeed = 45f;

    [SerializeField] private MobileController gasPedalButton;
    [SerializeField] private MobileController brakePedalButton;
    [SerializeField] private MobileController brakeLeverButton;
    [SerializeField] private MobileController moveRight;
    [SerializeField] private MobileController moveLeft;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        // Steering Input
        if (moveLeft != null && moveLeft.isPressed)
        {
            horizontalInput = -1;
        }
        else if (moveRight != null && moveRight.isPressed)
        {
            horizontalInput = 1;
        } else
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }

        // Accelration Input
        //if (gasPedalButton != null && gasPedalButton.isPressed)
        //{
        //    verticalInput = 1;
        //    isBreaking = false;
        //} 
        //else if (brakePedalButton != null && brakePedalButton.isPressed)
        //{
        //    verticalInput = -1;
        //    isBreaking = false;
        //}
        //else if (brakeLeverButton != null && brakeLeverButton.isPressed)
        //{
        //    verticalInput = 0;
        //    isBreaking = true;
        //}
        //else
        //{
        //    verticalInput = Input.GetAxis("Vertical");
        //    isBreaking = Input.GetKey(KeyCode.Space);
        //}
    }

    private void HandleMotor()
    {
        //frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        //frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        //currentbreakForce = isBreaking ? breakForce : 0f;
        //ApplyBreaking();

        Vector3 newPosition = transform.position;
        newPosition.x += horizontalInput * moveSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    //private void ApplyBreaking()
    //{
    //    frontRightWheelCollider.brakeTorque = currentbreakForce;
    //    frontLeftWheelCollider.brakeTorque = currentbreakForce;
    //    rearLeftWheelCollider.brakeTorque = currentbreakForce;
    //    rearRightWheelCollider.brakeTorque = currentbreakForce;
    //}

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
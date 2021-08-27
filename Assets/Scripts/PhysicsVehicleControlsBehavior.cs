using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsVehicleControlsBehavior : MonoBehaviour
{
    public HingeJoint frontleft;
    public HingeJoint frontright;
    public HingeJoint backleft;
    public HingeJoint backright;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //Front left wheel
            JointMotor motor1 = frontleft.motor;
            motor1.targetVelocity = 500;
            frontleft.motor = motor1;

            //Front right wheel
            JointMotor motor2 = frontright.motor;
            motor2.targetVelocity = 500;
            frontright.motor = motor2;

            //Back left wheel
            JointMotor motor3 = backleft.motor;
            motor3.targetVelocity = 500;
            backleft.motor = motor3;

            //Back right wheel
            JointMotor motor4 = backright.motor;
            motor4.targetVelocity = 500;
            backright.motor = motor4;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Front left wheel
            JointMotor motor1 = frontleft.motor;
            motor1.targetVelocity = -500;
            frontleft.motor = motor1;

            //Front right wheel
            JointMotor motor2 = frontright.motor;
            motor2.targetVelocity = -500;
            frontright.motor = motor2;

            //Back left wheel
            JointMotor motor3 = backleft.motor;
            motor3.targetVelocity = -500;
            backleft.motor = motor3;

            //Back right wheel
            JointMotor motor4 = backright.motor;
            motor4.targetVelocity = -500;
            backright.motor = motor4;
        }
    }
}

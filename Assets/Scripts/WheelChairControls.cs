using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChairControls : MonoBehaviour
{

    WheelChairInputs inputs;

    [SerializeField]
    Rigidbody rightWheel;

    [SerializeField]
    Rigidbody leftWheel;

    [SerializeField]
    float torqueScale;

    bool rightPressed;


    private void Awake()
    {
        inputs = new WheelChairInputs();

        inputs.Enable();
    }


    float TorqueScale => inputs.Keyboard.Shift.IsPressed() ? -torqueScale : torqueScale;

    private void FixedUpdate()
    {
        if (inputs.Keyboard.Right.IsPressed())
        {
            print("Right!");
            rightWheel.AddTorque(rightWheel.transform.right * TorqueScale, ForceMode.Acceleration);
        }

        if (inputs.Keyboard.Left.IsPressed())
        {
            print("Left!");
            leftWheel.AddTorque(-leftWheel.transform.right * TorqueScale, ForceMode.Acceleration);
        }
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

}

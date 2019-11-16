using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        TestAxisInput("Horizontal");
        TestAxisInput("Vertical");

        TestButtonInput("Fire1");
        TestButtonInput("Fire2");
        TestButtonInput("Fire3");
        TestButtonInput("Jump");

        TestAxisInput("Mouse X");
        TestAxisInput("Mouse Y");

        TestAxisInput("Mouse ScrollWheel");

        TestButtonInput("Submit");
        TestButtonInput("Cancel");
        */

        TestAxisInput("Left Player Horizontal");
        TestAxisInput("Left Player Vertical");
        TestAxisInput("Left Player D-Pad Horizontal");
        TestAxisInput("Left Player D-Pad Vertical");
        TestAxisInput("Left Player Trigger");
        TestButtonInput("Left Player Bumper");

        TestAxisInput("Right Player Horizontal");
        TestAxisInput("Right Player Vertical");
        TestButtonInput("Right Player Button Horizontal");
        TestButtonInput("Right Player Button Vertical");
        TestAxisInput("Right Player Trigger");
        TestButtonInput("Right Player Bumper");

        TestButtonInput("Left Player Joystick Click");
        TestButtonInput("Right Player Joystick Click");

        TestButtonInput("Start");
        TestButtonInput("Back");
    }

    private void TestButtonInput(string input)
    {
        if (Input.GetButtonDown(input))
        {
            Debug.Log(input + " " + Input.GetAxis(input));
        }
    }

    private void TestAxisInput(string input)
    {
        float axis = Input.GetAxis(input);
        if (Mathf.Abs(axis) > 0.001)
        {
            Debug.Log(input + " " + axis);
        }
    }
}

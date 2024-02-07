/*
Alvaro Troncoso
Week 2 - Calculator 

Just a nice little bonus scripts for fun
Special Thanks to Unity Documentation: https://docs.unity3d.com/ScriptReference/Transform.Rotate.html
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMovement : MonoBehaviour
{
    // Declaring a public variable for a GameObject. More specifically for the directional light object in the scene
    public GameObject sun_object;

    // Speed for how much the sun rotate
    public int speed = 2;

    // Each time the user push a button, the sun will rotate by the x axis based on the speed
    public void sunRotateXAxis()
    {
        sun_object.transform.Rotate(0.0f + speed, 0.0f, 0.0f, Space.World);
    }
}

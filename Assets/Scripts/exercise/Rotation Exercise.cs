using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationExercise : MonoBehaviour
{
    public float AngularSpeed;
    public float TargetAngle = 90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.up, Color.red);


        float currentRotation = transform.rotation.eulerAngles.z + 90;



        if  (TargetAngle - currentRotation <= 0)
        {
            if (currentRotation > TargetAngle)
            {
                transform.Rotate(0, 0, -AngularSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (currentRotation < TargetAngle)
            {
                transform.Rotate(0, 0, AngularSpeed * Time.deltaTime);
            }
        }       
    }





}

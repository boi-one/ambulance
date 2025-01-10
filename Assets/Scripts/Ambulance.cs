using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Ambulance : MonoBehaviour
{
    public bool entered;
    private float speed = 15f;

    public Transform[] wheels;
    private float targetAngle = 0f;
    private float targetAngleWheels = 0f;
    private float rotationSpeed = 60f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!entered) return;

        if (Input.GetKey(KeyCode.W))
            transform.position += transform.up * (speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.position -= transform.up * (speed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, 0, targetAngle);
        targetAngleWheels = targetAngle;
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W))
                targetAngle -= (rotationSpeed * 3f) * Time.deltaTime;
            else if (Input.GetKey(KeyCode.S))
                targetAngle += (rotationSpeed * 3f) * Time.deltaTime;
            if (targetAngleWheels >  -20 + targetAngle) targetAngleWheels -= rotationSpeed * Time.deltaTime;
        }
        else if (targetAngleWheels < targetAngle)
        {
            targetAngleWheels += rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W))
                targetAngle += (rotationSpeed * 3f) * Time.deltaTime;
            else if (Input.GetKey(KeyCode.S))
                targetAngle -= (rotationSpeed * 3f) * Time.deltaTime;
            if (targetAngleWheels < 20 + targetAngle) targetAngleWheels += rotationSpeed * Time.deltaTime;
        }
        else if (targetAngleWheels > targetAngle)
        {
            targetAngleWheels -= rotationSpeed * Time.deltaTime;
        }

        foreach (Transform wheel in wheels)
        {
            wheel.rotation = Quaternion.Euler(0, 0, targetAngleWheels);
        }
    }
}

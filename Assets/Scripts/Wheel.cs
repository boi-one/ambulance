using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    float angle = 0;
    void Start()
    {

    }

    void Update()
    {


        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}

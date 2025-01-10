using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Ambulance ambulance; 
    private float speed = 5f;
    private float ambulanceDistance = 0f;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.nearClipPlane;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        float angle = Mathf.Atan2(mouseWorldPosition.y - transform.position.y, mouseWorldPosition.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);

        if (Input.GetKeyDown(KeyCode.E) && ambulanceDistance < 2 && !ambulance.entered)
        {
            ambulance.entered = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && ambulance.entered) ambulance.entered = false;

        if(ambulance.entered)
        {
            transform.localScale = new Vector3(0, 0, 0);
            transform.position = ambulance.transform.position;
        }
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += new Vector3(0, 1, 0) * (speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.position -= new Vector3(1, 0, 0) * (speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.position -= new Vector3(0, 1, 0) * (speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(1, 0, 0) * (speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift)) 
            speed = 7f;
        else
            speed = 5;
    }
}

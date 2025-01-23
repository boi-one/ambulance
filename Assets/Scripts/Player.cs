using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Ambulance ambulance;
    private float speed = 5f;
    private Vector3 direction;
    private float ambulanceDistance = 0f;
    private Rigidbody2D rb;
    Dictionary<KeyCode, Vector3> directions = new Dictionary<KeyCode, Vector3>()
    {
        {KeyCode.W, new Vector3( 0,  1) },
        {KeyCode.A, new Vector3(-1,  0) },
        {KeyCode.S, new Vector3( 0, -1) },
        {KeyCode.D, new Vector3( 1,  0) },
    };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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


        ambulanceDistance = (transform.position - ambulance.transform.position).magnitude;
        if (ambulance.entered)
            Camera.main.transform.position = new Vector3(ambulance.transform.position.x, ambulance.transform.position.y, Camera.main.transform.position.z);
        else
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);

        if (Input.GetKeyDown(KeyCode.E) && ambulanceDistance < 3f && !ambulance.entered)
        {
            ambulance.entered = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && ambulance.entered)
        {
            ambulance.entered = false;
            transform.position = ambulance.transform.position + -ambulance.transform.right * 2;
        }
        if (ambulance.entered)
        {
            transform.localScale = new Vector3(0, 0, 0);
            transform.position = ambulance.transform.position;
        }
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    void Movement()
    {
        foreach(KeyValuePair<KeyCode, Vector3> pair in directions)
        {
            if (Input.GetKeyDown(pair.Key)) direction += pair.Value;
            else if(Input.GetKeyUp(pair.Key)) direction -= pair.Value;

            rb.velocity = direction * speed;
        }
    }
}

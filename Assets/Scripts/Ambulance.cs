using UnityEngine;

public class Engine
{
    public float velocity = 0;
    public float direction = 0;
    private float increaseSteps = 5f;
    public float maxVelocity = 20f;

    public void UpdateVelocity()
    {
        Debug.Log(velocity);

        if (direction != 0) 
        {
            velocity += direction * (increaseSteps * Time.deltaTime);
        }
        else if (velocity > 0) velocity -= increaseSteps * (1.5f * Time.deltaTime);
        else if (velocity < 0) velocity += increaseSteps * (1.5f * Time.deltaTime);

    }
};

public class Ambulance : MonoBehaviour
{
    public bool entered;

    Engine engine = new Engine();
    public Transform[] wheels;
    private float targetAngle = 0f;
    private float rotationSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!entered) return;
        rotationSpeed = engine.velocity * 2f;
        transform.position += transform.up * (engine.velocity * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, targetAngle);
        engine.UpdateVelocity();

        if (Input.GetKey(KeyCode.W))
        {
            engine.direction = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            engine.direction = -1;
        }
        else engine.direction = 0;

        if (Input.GetKey(KeyCode.A)) Rotate(-1);
        if (Input.GetKey(KeyCode.D)) Rotate(1);


    }

    void Rotate(float direction)
    {
        //if (engine.speed == 0) return;
        if (engine.velocity < 0)
            targetAngle += (-direction * rotationSpeed * 3f) * Time.deltaTime;
        else if (engine.direction >= 0 || engine.velocity > 0)
            targetAngle += (-direction * rotationSpeed * 3f) * Time.deltaTime;


    }
}

using UnityEngine;

public class Engine
{
    public float velocity = 0;
    public float direction = 0;
    private float increaseSteps = 5f;
    public float maxVelocity = 20f;
    public bool brake = false;

    public void UpdateVelocity(bool brake)
    {
        float decreaseSteps = increaseSteps * 1.5f;
        if (brake) decreaseSteps = increaseSteps * 3f;

        if (direction != 0) 
        {
            velocity += direction * (increaseSteps * Time.deltaTime);
        }
        else if (velocity > 0) velocity -= decreaseSteps * (1.5f * Time.deltaTime);
        else if (velocity < 0) velocity += decreaseSteps * (1.5f * Time.deltaTime);

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
        engine.UpdateVelocity(engine.brake);
        if (!entered) return;
        rotationSpeed = engine.velocity * 2f;
        transform.position += transform.up * (engine.velocity * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, targetAngle);

        if (Input.GetKey(KeyCode.W) && !engine.brake)
        {
            engine.direction = 1;
        }
        else if (Input.GetKey(KeyCode.S) && !engine.brake)
        {
            engine.direction = -1;
        }
        else engine.direction = 0;

        if (Input.GetKey(KeyCode.A)) Rotate(-1);
        if (Input.GetKey(KeyCode.D)) Rotate(1);
        if (Input.GetKeyDown(KeyCode.Space)) engine.brake = true;
        if (Input.GetKeyUp(KeyCode.Space)) engine.brake = false;
    }

    void Rotate(float direction)
    {
        float turnSpeed = rotationSpeed;
        if (engine.brake && engine.velocity > 5) turnSpeed *= 3;
        if (engine.velocity < 0)
            targetAngle += (-direction * turnSpeed * 3f) * Time.deltaTime;
        else if (engine.direction >= 0 || engine.velocity > 0)
            targetAngle += (-direction * turnSpeed * 3f) * Time.deltaTime;


    }
}

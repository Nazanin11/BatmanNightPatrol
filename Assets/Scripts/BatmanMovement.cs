
using UnityEngine;

public class BatmanMovement : MonoBehaviour
{
    public float normalSpeed = 5f;    // سرعت حالت Normal
    public float stealthSpeed = 2f;   // سرعت حالت Stealth (کمتر)
    public float sprintMultiplier = 2f;

    public float rotationSpeed = 200f;

    private CharacterController controller;
    public BatmanStateManager stateManager;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveBatman();
    }

    void MoveBatman()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        float speed = normalSpeed;

        if (stateManager.currentState == BatmanState.Stealth)
            speed = stealthSpeed;
        else if (stateManager.currentState == BatmanState.Normal)
        {
           
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                speed *= sprintMultiplier;
        }


        Vector3 move = new Vector3(0f, 0f, vertical * speed * Time.deltaTime);
        controller.Move(move);

        transform.Rotate(0f, horizontal * rotationSpeed * Time.deltaTime, 0f);
    }
}

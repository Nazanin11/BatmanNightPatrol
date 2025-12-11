using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float sprintSpeed = 10f;
    public float rotationSpeed = 200f;

    private CharacterController controller;

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

      
        float speed = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ? sprintSpeed : normalSpeed;

       
        Vector3 move = new Vector3(0f, 0f, vertical * speed * Time.deltaTime);
        controller.Move(move);

       
        transform.Rotate(0f, horizontal * rotationSpeed * Time.deltaTime, 0f);

    }
}

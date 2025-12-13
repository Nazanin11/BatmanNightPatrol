using UnityEngine;

/// <summary>
/// کنترل حرکت بتمن:
/// حرکت رو به جلو/عقب، چرخش چپ/راست
///  (Normal / Stealth) و مدیریت سرعت بر اساس حالت
/// </summary>
public class BatmanMovement : MonoBehaviour
{
    public float normalSpeed = 5f;    //  normal سرعت حالت 
    public float stealthSpeed = 2f;   //Stealth سرعت حالت 
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

    /// <summary>
    /// محاسبه و اعمال حرکت بتمن بر اساس ورودی و حالت فعلی
    /// </summary>
    void MoveBatman()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        float speed = normalSpeed;

        //State تغییر سرعت بر اساس 
        if (stateManager.currentState == BatmanState.Stealth)
            speed = stealthSpeed;
        else if (stateManager.currentState == BatmanState.Normal)
        {
            // Normal دویدن فقط در حالت 
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                speed *= sprintMultiplier;
        }

        // حرکت رو به جلو/عقب
        Vector3 move = new Vector3(0f, 0f, vertical * speed * Time.deltaTime);
        controller.Move(move);

        // چرخش چپ/راست
        transform.Rotate(0f, horizontal * rotationSpeed * Time.deltaTime, 0f);
    }
}

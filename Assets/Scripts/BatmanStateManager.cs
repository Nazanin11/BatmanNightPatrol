using UnityEngine;

public enum BatmanState { Normal, Stealth, Alert }

public class BatmanStateManager : MonoBehaviour
{
    public BatmanState currentState = BatmanState.Normal;

    public Light mainLight;             // نور محیط
    public AlertSystem alertSystem;     // سیستم نور + صدای Alert

    void Start()
    {
        // شروع بازی در حالت Normal
        SetState(BatmanState.Normal);
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.N))
            SetState(BatmanState.Normal);

        if (Input.GetKeyDown(KeyCode.C))
            SetState(BatmanState.Stealth);

        if (Input.GetKeyDown(KeyCode.Space))
            SetState(BatmanState.Alert);
    }

    void SetState(BatmanState newState)
    {
        currentState = newState;

        if (currentState == BatmanState.Normal)
        {
            mainLight.intensity = 2f;
            alertSystem.SetAlert(false);
        }
        else if (currentState == BatmanState.Stealth)
        {
            mainLight.intensity = 0.5f;
            alertSystem.SetAlert(false);
        }
        else if (currentState == BatmanState.Alert)
        {
            mainLight.intensity = 3f;
            alertSystem.SetAlert(true);
        }
    }
}

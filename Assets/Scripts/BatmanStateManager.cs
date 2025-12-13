using UnityEngine;

/// <summary>
/// حالت‌های مختلف بتمن
/// </summary>
public enum BatmanState { Normal, Stealth, Alert }

/// <summary>
/// مدیریت حالت‌های بتمن:
/// Normal، Stealth و Alert
/// هر حالت روی نور محیط و سیستم هشدار تأثیر می‌گذارد
/// </summary>
public class BatmanStateManager : MonoBehaviour
{
    public BatmanState currentState = BatmanState.Normal;

    public Light mainLight;         // نور اصلی محیط
    public AlertSystem alertSystem; //(سیستم هشدار (نور و صدا

    void Start()
    {
        // بازی همیشه از حالت نرمال شروع می‌شود
        SetState(BatmanState.Normal);
    }

    void Update()
    {
        HandleInput();
    }

    /// <summary>
    /// دریافت ورودی کیبورد برای تغییر حالت بتمن
    /// </summary>
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.N))
            SetState(BatmanState.Normal);

        if (Input.GetKeyDown(KeyCode.C))
            SetState(BatmanState.Stealth);

        if (Input.GetKeyDown(KeyCode.Space))
            SetState(BatmanState.Alert);
    }

    /// <summary>
    /// تغییر حالت بتمن و اعمال رفتار مربوط به هر حالت
    /// </summary>
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

using UnityEngine;

/// <summary>
/// کنترل Bat-Signal:
///  B روشن/خاموش شدن با کلید 
/// و چرخش آرام نور در آسمان به‌صورت رفت و برگشتی
/// </summary>
public class BatSignal : MonoBehaviour
{
    public Light batLight;          // نور بت‌سیگنال
    public float intensity = 100000f;
    public float speed = 0.05f;

    // بازه چرخش نور در آسمان
    public Vector3 minRot = new Vector3(-5f, 265f, -466f);
    public Vector3 maxRot = new Vector3(1f, 432f, -432f);

    private bool active = false;
    private float timer = 0f;

    void Start()
    {
        // اگر نور به‌صورت دستی مقداردهی نشده بود، از فرزند بگیر
        if (batLight == null)
            batLight = GetComponentInChildren<Light>();

        // در شروع بازی خاموش باشد
        batLight.intensity = 0f;
    }

    void Update()
    {
        //Bat-Signal روشن/خاموش کردن 
        if (Input.GetKeyDown(KeyCode.B))
        {
            active = !active;
            batLight.intensity = active ? intensity : 0f;
        }

        // در صورت فعال بودن، چرخش آرام انجام شود
        if (active)
        {
            timer += Time.deltaTime * speed;
            RotatePingPong();
        }
    }

    /// <summary>
    /// Bat-Signalچرخش رفت و برگشتی نور 
    /// بدون تغییر موقعیت
    /// </summary>
    void RotatePingPong()
    {
        Vector3 newRot;

        newRot.x = Mathf.Lerp(minRot.x, maxRot.x, Mathf.PingPong(timer, 1f));
        newRot.y = Mathf.Lerp(minRot.y, maxRot.y, Mathf.PingPong(timer, 1f));
        newRot.z = Mathf.Lerp(minRot.z, maxRot.z, Mathf.PingPong(timer, 1f));

        transform.eulerAngles = newRot;
    }
}

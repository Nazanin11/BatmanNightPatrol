using UnityEngine;

/// <summary>
/// سیستم هشدار (Alert):
/// مدیریت نورهای چشمک‌زن قرمز و آبی
///Alert و پخش/توقف صدای آلارم هنگام ورود یا خروج از حالت 
/// </summary>
public class AlertSystem : MonoBehaviour
{
    public Light redLight;     // نور قرمز هشدار
    public Light blueLight;    // نور آبی هشدار

    public AudioSource alarmAudio; // صدای آلارم

    public float blinkInterval = 0.3f; // فاصله زمانی چشمک‌زدن نورها
    private float timer = 0f;

    private bool isAlert = false; // وضعیت فعال بودن هشدار

    void Start()
    {
        // در شروع بازی، همه چیز خاموش باشد
        redLight.enabled = false;
        blueLight.enabled = false;

        if (alarmAudio != null)
            alarmAudio.Stop();
    }

    /// <summary>
    /// فعال یا غیرفعال کردن حالت هشدار
    /// </summary>

    public void SetAlert(bool active)
    {
        isAlert = active;

        if (!active)
        {
            //Alert خروج از حالت 
            redLight.enabled = false;
            blueLight.enabled = false;

            if (alarmAudio.isPlaying)
                alarmAudio.Stop();
        }
        else
        {
            //Alert ورود به حالت 
            if (!alarmAudio.isPlaying)
                alarmAudio.Play();
        }
    }

    void Update()
    {
        // اگر در حالت هشدار نیستیم، کاری نکن
        if (!isAlert) return;

        // مدیریت چشمک‌زدن نورها
        timer += Time.deltaTime;

        if (timer >= blinkInterval)
        {
            timer = 0f;
            redLight.enabled = !redLight.enabled;
            blueLight.enabled = !blueLight.enabled;
        }
    }
}

using UnityEngine;

public class AlertSystem : MonoBehaviour
{
    public Light redLight;
    public Light blueLight;

    public AudioSource alarmAudio;

    public float blinkInterval = 0.3f;
    private float timer = 0f;

    private bool isAlert = false;

    void Start()
    {
        // مطمئن می‌شویم همه چیز خاموش است
        redLight.enabled = false;
        blueLight.enabled = false;
        if (alarmAudio != null)
            alarmAudio.Stop();
    }

    public void SetAlert(bool active)
    {
        isAlert = active;

        if (!active)
        {
            redLight.enabled = false;
            blueLight.enabled = false;
            if (alarmAudio.isPlaying) alarmAudio.Stop();
        }
        else
        {
            if (!alarmAudio.isPlaying) alarmAudio.Play();
        }
    }

    void Update()
    {
        if (!isAlert) return;

        timer += Time.deltaTime;

        if (timer >= blinkInterval)
        {
            timer = 0f;
            redLight.enabled = !redLight.enabled;
            blueLight.enabled = !blueLight.enabled;
        }
    }
}

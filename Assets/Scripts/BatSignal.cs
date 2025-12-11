using UnityEngine;

public class BatSignal : MonoBehaviour
{

    public Light batLight;

    public float intensity = 100000f;
    public float speed = 0.05f;

    public Vector3 minRot = new Vector3(-5f, 265f, -466f);
    public Vector3 maxRot = new Vector3(1f, 432f, -432f);

    private bool active = false;
    private float timer = 0f;

    void Start()
    {
        if (batLight == null)
            batLight = GetComponentInChildren<Light>();

        batLight.intensity = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            active = !active;
            batLight.intensity = active ? intensity : 0f;

           
        }

        if (active)
        {
            timer += Time.deltaTime * speed;
            RotatePingPong();
        }
    }

    void RotatePingPong()
    {
        Vector3 newRot;

        newRot.x = Mathf.Lerp(minRot.x, maxRot.x, Mathf.PingPong(timer, 1f));
        newRot.y = Mathf.Lerp(minRot.y, maxRot.y, Mathf.PingPong(timer, 1f));
        newRot.z = Mathf.Lerp(minRot.z, maxRot.z, Mathf.PingPong(timer, 1f));

        transform.eulerAngles = newRot;
    }
}


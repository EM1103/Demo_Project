using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform[] backgrounds; // Array of background layers
    public float[] parallaxScales; // Multiplier for each layer's movement
    public float smoothing = 1f; // Controls how smooth the effect is

    private Vector3 previousCamPos;
    private Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
        previousCamPos = cam.position;

        // Assign default parallax scales if not set
        if (parallaxScales.Length == 0)
        {
            parallaxScales = new float[backgrounds.Length];
            for (int i = 0; i < backgrounds.Length; i++)
            {
                parallaxScales[i] = (i + 1) * 0.5f; // Adjust for more depth
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
            float backgroundTargetX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;
    }
}

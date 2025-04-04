using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorTransition : MonoBehaviour
{
    public Transform newCameraAnchor; // Target anchor
    public Vector2 newMinOffset, newMaxOffset; // New swipe limits relative to the anchor
    public Image fadeScreen;
    public float fadeSpeed = 1f;

    private bool isTransitioning = false;

    void OnMouseDown()
    {
        if (!isTransitioning)
            StartCoroutine(FadeAndMoveAnchor());
    }

    IEnumerator FadeAndMoveAnchor()
    {
        isTransitioning = true;

        // Step 1: Fade to Black
        yield return StartCoroutine(Fade(1));

        // Step 2: Move the Camera Anchor and Update Limits
        CameraController cameraController = GameObject.Find("CameraAnchor").GetComponent<CameraController>();
        cameraController.SetAnchor(newCameraAnchor, newMinOffset, newMaxOffset);

        // Step 3: Fade Back In
        yield return StartCoroutine(Fade(0));

        isTransitioning = false;
    }

    IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeScreen.color.a;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * fadeSpeed;
            Color newColor = fadeScreen.color;
            newColor.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            fadeScreen.color = newColor;
            yield return null;
        }
    }
}

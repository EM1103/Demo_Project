using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorTransition : MonoBehaviour
{
    public Transform outsideCameraPosition; // New camera position
    public Image fadeScreen; // UI Image for fade effect
    public float fadeSpeed = 1f; // Speed of fade effect

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        fadeScreen.gameObject.SetActive(true); // Ensure fade screen is active
    }

    void OnMouseDown()
    {
        StartCoroutine(FadeAndTeleport());
    }

    IEnumerator FadeAndTeleport()
    {
        // Step 1: Fade to Black
        yield return StartCoroutine(Fade(1));

        // Step 2: Instantly move the camera
        mainCamera.transform.position = outsideCameraPosition.position;

        // Step 3: Fade Back In
        yield return StartCoroutine(Fade(0));
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

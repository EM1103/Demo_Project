using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorTransition : MonoBehaviour
{
    public Anchor targetAnchor;
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

        yield return StartCoroutine(Fade(1));

        CameraController camera = GameObject.Find("CameraAnchor").GetComponent<CameraController>();
        camera.SnapToAnchor(targetAnchor);

        yield return StartCoroutine(Fade(0));

        isTransitioning = false;
    }

    IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeScreen.color.a;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * fadeSpeed;
            Color c = fadeScreen.color;
            c.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            fadeScreen.color = c;
            yield return null;
        }
    }
}

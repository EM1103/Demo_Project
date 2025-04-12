using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class StatLockedDoor : MonoBehaviour
{
    public Anchor targetAnchor;
    public Image fadeScreen;
    public float fadeSpeed = 1f;

    [Header("Stat Requirement")]
    public string requiredStat = "curiosity";
    public int requiredValue = 5;

    [Header("Warning Message UI")]
    public TMP_Text warningText;
    public float messageFadeDuration = 2f; // Seconds to show the warning before fading

    private bool isTransitioning = false;

    void OnMouseDown()
    {
        if (isTransitioning) return;

        if (!MeetsStatRequirement())
        {
            ShowWarning("You need more " + requiredStat + " to go through.");
            return;
        }

        StartCoroutine(FadeAndMoveAnchor());
    }

    bool MeetsStatRequirement()
    {
        switch (requiredStat.ToLower())
        {
            case "empathy": return PlayerStats.Instance.empathy >= requiredValue;
            case "curiosity": return PlayerStats.Instance.curiosity >= requiredValue;
            case "defiance": return PlayerStats.Instance.defiance >= requiredValue;
            case "resolve": return PlayerStats.Instance.resolve >= requiredValue;
            case "corruption": return PlayerStats.Instance.corruption >= requiredValue;
            default:
                Debug.LogWarning("Unknown stat: " + requiredStat);
                return false;
        }
    }

    void ShowWarning(string message)
    {
        if (warningText == null) return;

        warningText.text = message;
        warningText.alpha = 1f;
        StopAllCoroutines(); // Stop previous fade if still running
        StartCoroutine(FadeOutText());
    }

    IEnumerator FadeOutText()
    {
        yield return new WaitForSeconds(messageFadeDuration);

        float fadeTime = 1f;
        float elapsed = 0f;
        Color originalColor = warningText.color;

        while (elapsed < fadeTime)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeTime);
            warningText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }
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

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
    public string requiredStat = "";
    public int requiredValue = 0;

    [Header("Warning Message UI")]
    public TMP_Text warningText;
    public float messageFadeDuration = 2f; // Seconds to show the warning before fading

    private bool isTransitioning = false;

    [TextArea]
    public string[] insufficientStatMessages = new string[]
    {
        "The door won't budge...",
        "Something is missing...",
        "You are missing something...",
        "The door won't move.",
        "Not yet."
    };

    void OnMouseDown()
    {
        if (isTransitioning) return;

        if (!MeetsStatRequirement())
        {
            string randomMessage = insufficientStatMessages[Random.Range(0, insufficientStatMessages.Length)];
            ShowWarning(randomMessage);
            return;
        }

        StartCoroutine(FadeAndMoveAnchor());
    }

    bool MeetsStatRequirement()
    {
        switch (requiredStat.ToLower())
        {
            // For core stats
            case "empathy": return PlayerStats.Instance.empathy >= requiredValue;
            case "curiosity": return PlayerStats.Instance.curiosity >= requiredValue;
            case "defiance": return PlayerStats.Instance.defiance >= requiredValue;
            case "resolve": return PlayerStats.Instance.resolve >= requiredValue;
            case "corruption": return PlayerStats.Instance.corruption >= requiredValue;
            // For chapter keys
            case "key_p": return PlayerStats.Instance.key_p >= requiredValue;
            case "key_1": return PlayerStats.Instance.key_1 >= requiredValue;
            case "key_2": return PlayerStats.Instance.key_2 >= requiredValue;
            case "key_3": return PlayerStats.Instance.key_3 >= requiredValue;
            case "key_4": return PlayerStats.Instance.key_4 >= requiredValue;
            case "key_5": return PlayerStats.Instance.key_5 >= requiredValue;
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

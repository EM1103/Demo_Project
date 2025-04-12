using System.Collections;
using UnityEngine;
using TMPro;

public class TouchTextPopup : MonoBehaviour
{
    [Header("Text Settings")]
    public string message = "This is a popup message!";
    public float duration = 3f;
    public TextMeshProUGUI popupText;

    private bool isShowing = false;
    private Coroutine popupRoutine;

    void OnMouseDown()
    {
        if (!isShowing)
        {
            popupRoutine = StartCoroutine(ShowMessage());
        }
    }

    IEnumerator ShowMessage()
    {
        isShowing = true;

        popupText.text = message;
        Color originalColor = popupText.color;

        // Fade in
        yield return StartCoroutine(FadeText(0f, 1f, 0.5f));

        // Wait
        yield return new WaitForSeconds(duration);

        // Fade out
        yield return StartCoroutine(FadeText(1f, 0f, 0.5f));

        popupText.text = "";
        popupText.color = originalColor;
        isShowing = false;
    }

    IEnumerator FadeText(float from, float to, float time)
    {
        float elapsed = 0f;
        Color c = popupText.color;

        while (elapsed < time)
        {
            c.a = Mathf.Lerp(from, to, elapsed / time);
            popupText.color = c;
            elapsed += Time.deltaTime;
            yield return null;
        }

        c.a = to;
        popupText.color = c;
    }
}

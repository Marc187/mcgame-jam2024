using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SequentialFadeUI : MonoBehaviour
{
    public List<Graphic> uiElements; // Can be Text, Image, etc.
    public float displayTime = 12f;
    public float fadeDuration = 2f;

    void Start()
    {
        StartCoroutine(FadeUIElementsInAndOut());
    }

    IEnumerator FadeUIElementsInAndOut()
    {
        foreach (var element in uiElements)
        {
            // Start fading in
            yield return StartCoroutine(FadeGraphicAlpha(element, 0f, 1f, fadeDuration));

            // Wait for the display time
            yield return new WaitForSeconds(displayTime - (2 * fadeDuration));

            // Start fading out
            yield return StartCoroutine(FadeGraphicAlpha(element, 1f, 0f, fadeDuration));
        }
    }

    IEnumerator FadeGraphicAlpha(Graphic graphic, float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;
        Color color = graphic.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            graphic.color = new Color(color.r, color.g, color.b, newAlpha);
            yield return null;
        }

        graphic.color = new Color(color.r, color.g, color.b, endAlpha);
    }
}
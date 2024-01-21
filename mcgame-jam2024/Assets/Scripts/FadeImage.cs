using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SequentialFadeImages : MonoBehaviour
{
    public List<Image> imagesToFade; // List to hold only Image components
    public float displayTime = 12f;
    public float fadeDuration = 2f;

    void Start()
    {
        StartCoroutine(FadeImagesInAndOut());
    }

    IEnumerator FadeImagesInAndOut()
    {
        foreach (var image in imagesToFade)
        {
            // Start fading in
            yield return StartCoroutine(FadeImageAlpha(image, 0f, 1f, fadeDuration));

            // Wait for the display time
            yield return new WaitForSeconds(displayTime - (2 * fadeDuration));

            // Start fading out
            yield return StartCoroutine(FadeImageAlpha(image, 1f, 0f, fadeDuration));
        }
    }

    IEnumerator FadeImageAlpha(Image image, float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;
        Color color = image.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            image.color = new Color(color.r, color.g, color.b, newAlpha);
            yield return null;
        }

        image.color = new Color(color.r, color.g, color.b, endAlpha);
    }
}
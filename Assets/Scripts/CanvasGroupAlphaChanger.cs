using UnityEngine;
using UnityEngine.UI;

public class CanvasGroupAlphaChanger : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1f;
    

    public Timing timing;

    public Image borderImage;

    private float currentAlpha, targetAlpha, timer;

    void Start()
    {
        // Start with alpha set to 0
        currentAlpha = 0f;
        targetAlpha = 1f;
        timer = 0f;
    }

    void Update()
    {
        if (timing.isRed)
        {
            borderImage.color = Color.red;
        }
        else
        {
            borderImage.color = Color.white;
        }
        // Update the timer
        timer += Time.deltaTime;

        // Calculate the normalized time
        float normalizedTime = timer / fadeDuration;

        // Ensure normalized time is clamped between 0 and 1
        normalizedTime = Mathf.Clamp01(normalizedTime);

        // Calculate the new alpha value
        float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, normalizedTime);

        // Apply the new alpha value to the CanvasGroup
        canvasGroup.alpha = newAlpha;

        // If the lerping is done, swap the target and current alpha values
        if (normalizedTime >= 1f)
        {
            float temp = targetAlpha;
            targetAlpha = currentAlpha;
            currentAlpha = temp;

            // Reset the timer
            timer = 0f;
        }
    }
}
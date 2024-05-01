using UnityEngine;
using UnityEngine.UI;

public class CanvasGroupAlphaChanger : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1f;
    

    public Timing timing;

    public Image borderImage;

    private float currentAlpha, targetAlpha, timer, redTimer;

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
            redTimer += Time.deltaTime;
        }
        else
        {
            borderImage.color = Color.white;
            redTimer = 0f;
        }

        if (redTimer >= 5f)
        {
            canvasGroup.alpha = 1;
            if (timing.moveProvider != null && timing.upDownSystem != null)
            {
                timing.moveProvider.moveSpeed = 0;
                timing.upDownSystem.moveSpeed = 0;
            }
            return;
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

        if (canvasGroup.alpha == 0)
        {
            fadeDuration = 0.1f;
        }
        else if (canvasGroup.alpha >= 1f)
        {
            fadeDuration = 1.5f;
        }

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
using System.Collections;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    public GameObject backgroundColor;
    public Color DefaultColor = Color.white;
    public Color HighLightColor;
    public float LerpSpeed = 0.5f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        if (backgroundColor != null)
        {
            spriteRenderer = backgroundColor.GetComponent<SpriteRenderer>();

            if (spriteRenderer == null)
            {
                Debug.LogError("SpriteRenderer component missing on BackgroundSquare!");
            }
            else
            {
                spriteRenderer.color = DefaultColor; // Sets initial color
            }
        }
        else
        {
            Debug.LogError("BackgroundColor reference is missing in ColorLerp!");
        }
    }

    public IEnumerator UpdateColor()
    {
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is null in UpdateColor!");
            yield break;
        }

        Debug.Log("Starting color lerp...");
        float lerpProgress = 0f;

        while (lerpProgress < 1f)
        {
            lerpProgress += Time.deltaTime * LerpSpeed;
            Color lerpedColor = Color.Lerp(DefaultColor, HighLightColor, lerpProgress);
            spriteRenderer.color = lerpedColor;

            Debug.Log($"Lerping Color: {lerpedColor}");
            yield return new WaitForEndOfFrame();
        }

        spriteRenderer.color = HighLightColor; // Ensures color reaches HighLightColor
        Debug.Log("Lerp complete!");
    }

    public void ResetColor()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = DefaultColor;
            Debug.Log("Color reset to DefaultColor.");
        }
    }
}

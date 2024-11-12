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
                spriteRenderer.color = DefaultColor;
            }
        }
    }

    public IEnumerator UpdateColor()
    {
        float lerpProgress = 0f;

        while (lerpProgress < 1f)
        {
            lerpProgress += Time.deltaTime * LerpSpeed;

            Color lerpedColor = Color.Lerp(DefaultColor, HighLightColor, lerpProgress);
            spriteRenderer.color = lerpedColor;

            yield return new WaitForEndOfFrame();
        }

        spriteRenderer.color = HighLightColor;
        
        DefaultColor = HighLightColor;
    }

    public void ResetColor()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = DefaultColor;
        }
    }
}

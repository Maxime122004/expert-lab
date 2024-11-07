using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    public Color DefaultColor = Color.white;
    public Color HighLightColor;
    public float LerpSpeed = 0.5f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.Log("SpriteRenderer component missing!");
            return;
        }

        DefaultColor = spriteRenderer.color;

        StartCoroutine(UpdateColor());
    }

    private IEnumerator UpdateColor()
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
    }
}
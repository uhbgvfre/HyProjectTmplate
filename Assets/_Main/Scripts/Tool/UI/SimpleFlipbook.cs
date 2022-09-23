using UnityEngine;
using UnityEngine.UI;

public class SimpleFlipbook : MonoBehaviour
{
    public float fps = 24f;
    public Sprite[] sprites;

    private Image m_ImageCache;
    private Image m_Image => m_ImageCache ??= GetComponent<Image>();

    private float m_PassedTime;
    private float GetFrameTick() => (fps <= 0) ? 0 : 1f / fps;

    private void Update()
    {
        if (sprites == null || sprites.Length == 0)
        {
            m_Image.sprite = null;
            return;
        }

        if (sprites.Length == 1)
        {
            m_Image.sprite = sprites[0];
            return;
        }

        m_PassedTime += Time.deltaTime;

        var frameQty = m_PassedTime / GetFrameTick();
        int frameIdx = (int)frameQty % sprites.Length;
        m_Image.sprite = sprites[frameIdx];
    }
}
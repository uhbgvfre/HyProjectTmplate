using UnityEngine;
using TMPro;

public class AppColorRef_Font : MonoBehaviour
{
    [SerializeField] private string m_ColorKey;
    private TextMeshProUGUI m_TextCache;
    private TextMeshProUGUI m_Text => m_TextCache ??= GetComponent<TextMeshProUGUI>();

    private void Update()
    {
        Color c = AppColorSheet.GetColor(m_ColorKey);
        if (m_Text.color != c) m_Text.color = c;
    }
}

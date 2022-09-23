using UnityEngine;
using UnityEngine.UI;

public class AppColorRef_Graphic : MonoBehaviour
{
    [SerializeField] private string m_ColorKey;
    private Graphic m_GraphicCache;
    private Graphic m_Graphic => m_GraphicCache ??= GetComponent<Graphic>();

    private void Update()
    {
        Color c = AppColorSheet.GetColor(m_ColorKey);
        if (m_Graphic.color != c) m_Graphic.color = c;
    }
}

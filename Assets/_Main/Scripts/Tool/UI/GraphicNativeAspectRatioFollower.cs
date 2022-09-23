using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(Graphic), typeof(AspectRatioFitter))]
public class GraphicNativeAspectRatioFollower : MonoBehaviour
{
    public bool controlWhileTextureIsNotDefault = true;

    private Graphic m_GraphicCache;
    private Graphic m_Graphic => m_GraphicCache ?? GetComponent<Graphic>();

    private AspectRatioFitter m_AspectRatioFitterCache;
    private AspectRatioFitter m_AspectRatioFitter => m_AspectRatioFitterCache ?? GetComponent<AspectRatioFitter>();

    private const string k_DefaultTextureName = "UnityWhite";

    private void LateUpdate()
    {
        if (m_Graphic == null || m_Graphic.mainTexture == null) return;

        bool isDefaultTexture = m_Graphic.mainTexture.name == k_DefaultTextureName;
        if (controlWhileTextureIsNotDefault && isDefaultTexture) return;

        m_AspectRatioFitter.aspectRatio = (float)m_Graphic.mainTexture.width / (float)m_Graphic.mainTexture.height;
    }
}
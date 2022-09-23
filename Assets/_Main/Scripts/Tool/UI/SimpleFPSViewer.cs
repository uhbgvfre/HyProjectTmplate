using UnityEngine;
using TMPro;

public class SimpleFPSViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fpsText;
    public float fps;

    private float[] m_DeltaTimeBuffer = new float[30];
    private int m_PassedFrameCount;

    private void Update()
    {
        m_DeltaTimeBuffer[m_PassedFrameCount++ % m_DeltaTimeBuffer.Length] = Time.deltaTime;
        CalcFPS();
        if (fpsText == null) return;
        fpsText.text = fps.ToString("0.0");
    }

    private void CalcFPS()
    {
        float dtSum = 0;
        foreach (float dt in m_DeltaTimeBuffer)
        {
            dtSum += dt;
        }

        fps = 1f / (dtSum / m_DeltaTimeBuffer.Length);
    }
}
using UnityEngine;

public class BoxColliderSizeFollower : MonoBehaviour
{
    private RectTransform m_TargetRTCache;
    private RectTransform m_TargetRT => m_TargetRTCache ?? GetComponent<RectTransform>();

    private BoxCollider m_BoxColCache;
    private BoxCollider m_BoxCol => m_BoxColCache ?? GetComponent<BoxCollider>();

    private void Update()
    {
        var size = new Vector3(m_TargetRT.rect.width, m_TargetRT.rect.height, 1f);
        if (m_BoxCol.size == size) return;
        m_BoxCol.size = size;
    }
}

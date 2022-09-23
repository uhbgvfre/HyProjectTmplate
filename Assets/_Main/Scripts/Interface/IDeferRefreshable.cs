using UnityEngine;

public abstract class IDeferRefreshable : MonoBehaviour
{
    private bool m_NeedRefresh = true;

    public void SetDirty() => m_NeedRefresh = true;

    protected virtual void LateUpdate()
    {
        if (m_NeedRefresh)
        {
            Refresh();
            m_NeedRefresh = false;
        }
    }

    // Refresh datas or relayout UI elements
    public virtual void Refresh() { }
}
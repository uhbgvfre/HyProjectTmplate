using UnityEngine;
using UniRx;

public class BindColliderActivityToCanvasGroupRaycastable : MonoBehaviour
{
    [SerializeField] private CanvasGroup m_CanvasGroup;

    private Collider m_Collider;

    private void Start()
    {
        m_Collider = GetComponent<Collider>();
        m_CanvasGroup.ObserveEveryValueChanged(x => x.blocksRaycasts)
            .Where(x => x != m_Collider.enabled)
            .Subscribe(x => m_Collider.enabled = x);
    }
}

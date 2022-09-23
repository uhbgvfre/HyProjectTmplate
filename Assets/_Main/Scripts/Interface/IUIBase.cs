using UnityEngine;
using UniRx;

public abstract class IUIBase : IDeferRefreshable
{
    [SerializeField] private bool m_HideOnStart = true;

    public ReactiveProperty<bool> IsShow { get; private set; } = new ReactiveProperty<bool>();

    protected virtual void Start()
    {
        if (m_HideOnStart) HideInstantly();
    }

    public void Show()
    {
        IsShow.Value = true;
        ShowBehaviour();
    }

    public void Hide()
    {
        IsShow.Value = false;
        HideBehaviour();
    }

    public void ShowInstantly()
    {
        IsShow.Value = true;
        ShowInstantlyBehaviour();
    }

    public void HideInstantly()
    {
        IsShow.Value = false;
        HideInstantlyBehaviour();
    }

    protected virtual GameObject m_ActivableTarget => gameObject; // Or override to child container
    protected virtual void ShowBehaviour() => ShowInstantlyBehaviour();
    protected virtual void HideBehaviour() => HideInstantlyBehaviour();
    protected virtual void ShowInstantlyBehaviour() => m_ActivableTarget.SetActive(true);
    protected virtual void HideInstantlyBehaviour() => m_ActivableTarget.SetActive(false);
    public virtual void ClearUIDataField() { } // Clear populatable data fields
    public virtual void ResetUIState() { } // Reset this UI cache state
}
using UnityEngine;
using Zenject;
using UniRx;

public class IdleCheckHelper : MonoBehaviour
{
    public Subject<Unit> idleNotifier = new Subject<Unit>();

    [Inject] private AppFlow m_AppFlow;

    private float m_IdleCheckDelay => AppConfig.IdleCheckDelay;
    private float m_LastInteractTime;

    private void Update()
    {
        if (HasAnyUserInput()) { m_LastInteractTime = Time.time; };

        var noInteractPeriod = Time.time - m_LastInteractTime;

        if (m_AppFlow.currentState == AppState.Init || m_AppFlow.currentState == AppState.Idle) return;

        if (noInteractPeriod > m_IdleCheckDelay) OnIdleDetected();
    }

    // 自訂義操作觸發行為
    private bool HasAnyUserInput()
    {
        return Input.touchCount > 0 || Input.GetMouseButton(0) || Input.anyKey;
    }

    // 閒置判定成功行為
    private void OnIdleDetected()
    {
        print("【!IdleDetected】 -> ResetState");
        idleNotifier.OnNext(default);
        m_AppFlow.ChangeToState(AppState.Idle);
    }
}
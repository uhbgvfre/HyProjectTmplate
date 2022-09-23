using UnityEngine;
using MonsterLove.StateMachine;
using DG.Tweening;

public enum AppState { Init, Start, Idle, Playing, }

public class AppFlow : MonoBehaviour
{
    public AppState currentState => m_AppFSM.State;

    private StateMachine<AppState> m_AppFSM;

    private void Start()
    {
        m_AppFSM = StateMachine<AppState>.Initialize(this);
        m_AppFSM.ChangeState(AppState.Init);
    }

    public void ChangeToState(AppState state) => m_AppFSM.ChangeState(state);

    private void Init_Enter() => DOTween.Init();

    private void Idle_Enter() => print("Idle_Enter");
    private void Idle_Update() => print("Idle_Update");
    private void Idle_Exit() => print("Idle_Exit");
}
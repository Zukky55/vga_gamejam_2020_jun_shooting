using UnityEngine;
using UniRx.Async;

namespace gamejam
{
    public class SelectCharactor : MonoBehaviour
    {
        private void Awake()
        {
            GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, OnEnter);
            GameManager.Instance.Statemachine.SubscribeEvent(When.Exit, OnExit);
        }

        private async void OnEnter(State obj)
        {
            if (!obj.Equals(State.SelectCharactor)) return;

            await UniTask.DelayFrame(1);
            GameManager.Instance.Statemachine.SetState(State.CountDown);
        }

        private void OnExit(State obj)
        {
            if (!obj.Equals(State.SelectCharactor)) return;
        }
    }
}

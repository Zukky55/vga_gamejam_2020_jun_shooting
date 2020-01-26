using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UniRx.Async;

namespace gamejam
{
    public class InitializeState : MonoBehaviour
    {

        private void Start  ()
        {
            GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, OnStateEnter);
            GameManager.Instance.Statemachine.SubscribeEvent(When.Exit, OnStateExit);
        }

        private async void OnStateEnter(State obj)
        {
            if (!obj.Equals(State.Initialize)) return;
            var gm = GameManager.Instance;
            await UniTask.WaitUntil(()=>gm.ResourceManager.IsInitialized);

            gm.Statemachine.SetState(State.Title);
        }

        private void OnStateExit(State obj)
        {
            if (!obj.Equals(State.Initialize)) return;
        }
    }

}

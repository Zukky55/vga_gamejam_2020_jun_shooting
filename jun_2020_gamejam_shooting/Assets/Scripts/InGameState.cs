using System;
using UniRx.Async;
using UnityEngine;

namespace gamejam
{
    public class InGameState : MonoBehaviour
    {
        public float ElapsedTime => elapsedTime - startTIme;

        float startTIme;
        float elapsedTime;
        private void Start()
        {
            GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, OnStateEnter);
            GameManager.Instance.Statemachine.SubscribeEvent(When.Exit, OnStateExit);
            GameManager.Instance.Statemachine.SubscribeEvent(When.Stay, OnStateStay);
        }

        private void OnStateStay(State obj)
        {
            if (!obj.Equals(State.InGame)) return;
        }

        private async void OnStateEnter(State obj)
        {
            if (!obj.Equals(State.InGame)) return;

            startTIme = elapsedTime = Time.timeSinceLevelLoad;

            await UniTask.DelayFrame(1);
            GameManager.Instance.Result(OwnerType.Player1);
        }

        private void OnStateExit(State obj)
        {
            if (!obj.Equals(State.InGame)) return;
        }


    }

}

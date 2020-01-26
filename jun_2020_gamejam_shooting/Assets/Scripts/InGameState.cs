using System;
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

        private void OnStateEnter(State obj)
        {
            if (!obj.Equals(State.InGame)) return;

            startTIme = elapsedTime = Time.timeSinceLevelLoad;

        }

        private void OnStateExit(State obj)
        {
            if (!obj.Equals(State.InGame)) return;
        }


    }

}

using System;
using UnityEngine;

namespace gamejam
{
    public class CountDown : MonoBehaviour
    {
        private void Awake()
        {
            GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, OnCountdownEnter);
        }

        private void OnCountdownEnter(State state)
        {
            if (state.Equals(State.CountDown)) return;
            // tds
        }
    }
}
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UniRx.Async;
using System.Collections.Generic;
using System;

namespace gamejam
{
    public class CountDownState : MonoBehaviour
    {
        [SerializeField]
        Sprite[] sprites = new Sprite[5];

        [SerializeField]
        SpriteRenderer sr;

        [SerializeField]
        GameObject countdownUI;

        int index = 0;

        private void Start()
        {
            GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, OnStateEnter);
            GameManager.Instance.Statemachine.SubscribeEvent(When.Stay, OnStateStay);

            if (!countdownUI)
            {
                countdownUI = gameObject;
            }
        }

        private async void OnStateStay(State obj)
        {
            if (!obj.Equals(State.CountDown)) return;


        }

        private async void OnStateEnter(State obj)
        {
            if (!obj.Equals(State.CountDown)) return;

            while (index < sprites.Length)
            {
                sr.sprite = sprites[index];
                ++index;
                await UniTask.Delay(TimeSpan.FromSeconds(1));
            }
            GameManager.Instance.Statemachine.SetState(State.InGame);
            Destroy(countdownUI);
        }
    }
}

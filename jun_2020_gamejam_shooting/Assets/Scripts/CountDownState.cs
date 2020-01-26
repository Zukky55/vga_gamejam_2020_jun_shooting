using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UniRx.Async;
using System.Collections.Generic;

namespace gamejam
{
    public class CountDownState : MonoBehaviour
    {
        [SerializeField]
        TimeParameter param;

        [SerializeField]
        Sprite[] sprites = new Sprite[5];

        [SerializeField]
        SpriteRenderer sr;

        [SerializeField]
        GameObject countdownUI;

        Timer timer;
        int index;

        private void Start()
        {
            GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, OnStateEnter);

            timer = new Timer(param);
            timer.OnEndTimer += Timer_OnEndTimer;
            timer.OnStopWatchEvent += Timer_OnStopWatchEvent;
            index = sprites.Length - 1;

            if (!countdownUI)
            {
                countdownUI = gameObject;
            }
        }

        private void Timer_OnStopWatchEvent()
        {
            --index;
            if (index >= 0)
            {
                sr.sprite = sprites[index];
            }
        }

        private void Timer_OnEndTimer()
        {
            GameManager.Instance.Statemachine.SetState(State.InGame);
            Destroy(gameObject);
        }

        private void Update()
        {
            timer.UpdateTimer();
        }

        private void OnStateEnter(State obj)
        {
            if (!obj.Equals(State.CountDown)) return;

            timer.StartTimer();

        }
    }
}

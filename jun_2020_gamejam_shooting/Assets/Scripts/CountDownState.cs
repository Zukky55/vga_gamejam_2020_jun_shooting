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

            for (int i = 0; i < 5; ++i) {
                var go = Resources.Load("bom") as GameObject;
                go = Instantiate(go, new Vector3(UnityEngine.Random.Range(-8.3f, 8.3f), UnityEngine.Random.Range(-3.3f, 5.3f), 0), Quaternion.identity);
                var bom = go.GetComponent<bom>();
            }

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

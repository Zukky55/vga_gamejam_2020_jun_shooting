using UnityEngine;
using System.Collections;
using System;
using UniRx;
using UniRx.Triggers;

namespace gamejam
{
    public class TitleState : MonoBehaviour
    {
        [SerializeField]
        GameObject title;
        [SerializeField]
        private bool useCountDown;

        private void Start()
        {
            GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, OnInitializeEnter);
            GameManager.Instance.Statemachine.SubscribeEvent(When.Stay, OnInitializeStay);
            GameManager.Instance.Statemachine.SubscribeEvent(When.Exit, OnInitializeExit);

            title.SetActive(false);
        }

        private void OnInitializeStay(State obj)
        {
            if (!obj.Equals(State.Title)) return;

            if (Input.GetAxis("Options") != 0)
            {
                Debug.Log($"Options押された");
                if (useCountDown)
                {
                GameManager.Instance.Statemachine.SetState(State.CountDown);
                }
                else
                {
                    GameManager.Instance.Statemachine.SetState(State.InGame);
                }
            }
        }

        private void OnInitializeEnter(State obj)
        {
            if (!obj.Equals(State.Title)) return;
            title.SetActive(true);
        }

        private void OnInitializeExit(State obj)
        {
            if (!obj.Equals(State.Title)) return;
            title.SetActive(false);
        }
    }

}

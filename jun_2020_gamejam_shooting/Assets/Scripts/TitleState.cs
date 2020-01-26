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

        private void Awake()
        {
            GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, OnInitializeEnter);
            GameManager.Instance.Statemachine.SubscribeEvent(When.Exit, OnInitializeExit);
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

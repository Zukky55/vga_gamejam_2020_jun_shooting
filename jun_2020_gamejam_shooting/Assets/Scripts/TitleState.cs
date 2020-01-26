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

        private void Start()
        {
            GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, OnInitializeEnter);
            GameManager.Instance.Statemachine.SubscribeEvent(When.Exit, OnInitializeExit);

            title.SetActive(false);
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

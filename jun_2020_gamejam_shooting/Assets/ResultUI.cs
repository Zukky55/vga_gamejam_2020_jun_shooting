using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using UniRx.Async;
using UnityEngine.SceneManagement;

namespace gamejam
{
    public class ResultUI : MonoBehaviour
    {
        [SerializeField]
        GameObject player1;
        [SerializeField]
        GameObject player2;

        [SerializeField]
        Button restartButton;
        [SerializeField]
        Button titleButton;
        [SerializeField]
        GameObject restartButtonFrame;
        [SerializeField]
        GameObject titleButtonFrame;

        public void Play(OwnerType winer)
        {
            GameObject go = null;
            switch (winer)
            {
                case OwnerType.player1:
                    go = player1;
                    break;
                case OwnerType.player2:
                    go = player2;
                    break;
                default:
                    throw new ArgumentException();
            }

            go.SetActive(true);

            restartButton.gameObject.SetActive(true);
            titleButton.gameObject.SetActive(true);

            this.UpdateAsObservable()
                .Select(_ => Input.GetAxis($"Horizontal"))
                .Where(val => val != 0f
                && !GameManager.Instance.Statemachine.CurrentState.Equals(State.GameEnd))
                .Subscribe(val =>
                {
                    if (val > 0f)
                    {
                        titleButtonFrame.SetActive(false);
                        titleButton.interactable = false;
                        restartButtonFrame.SetActive(true);
                        restartButton.interactable = true;
                    }
                    else
                    {
                        titleButtonFrame.SetActive(true);
                        restartButtonFrame.SetActive(false);
                        titleButton.interactable = true;
                        restartButton.interactable = false;
                    }
                })
                .AddTo(this);
        }
    }
}

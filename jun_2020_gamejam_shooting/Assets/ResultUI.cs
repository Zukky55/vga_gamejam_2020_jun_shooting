using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using UniRx.Async;

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

        public void Play(OwnerType winer)
        {
            GameObject go = null;
            switch (winer)
            {
                case OwnerType.Player1:
                    go = player1;
                    break;
                case OwnerType.Player2:
                    go = player1;
                    break;
                default:
                    throw new ArgumentException();
            }

            go.SetActive(true);

            restartButton.gameObject.SetActive(true);
            titleButton.gameObject.SetActive(true);
            restartButton.Select();

            //this.UpdateAsObservable()
            //    .Where(_ => Input.GetAxisRaw("Horizontal_") > 0)
            //    .
        }
    }
}

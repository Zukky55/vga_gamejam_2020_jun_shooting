using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace gamejam
{
    public class ResultUI : MonoBehaviour
    {
        [SerializeField]
        GameObject player1;
        [SerializeField]
        GameObject player2;

        internal void Play(OwnerType winer)
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
        }
    }
}

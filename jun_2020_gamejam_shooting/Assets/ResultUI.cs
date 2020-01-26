using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace gamejam
{
    public class ResultUI : MonoBehaviour
    {
        [SerializeField]
        Image player1;
        [SerializeField]
        Image player2;

        private void Awake()
        {

        }

        void SetColor(bool isPlayer1, Color color)
        {
            if (isPlayer1)
            {
                player1.color = color;
            }
            else
            {
                player1.color = color;
            }
        }

    }
}

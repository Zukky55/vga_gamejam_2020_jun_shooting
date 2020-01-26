using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam
{
    public class TitleButton : MonoBehaviour
    {
        public void OnClick()
        {
            GameManager.Instance.Statemachine.SetState(State.CountDown);
        }
    }
}

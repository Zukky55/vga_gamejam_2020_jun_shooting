using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam
{
    public class TitleButton : MonoBehaviour
    {
        public void OnClick()
        {

            Debug.Log($"よばれたで");
            GameManager.Instance.Statemachine.SetState(State.CountDown);
        }
    }
}

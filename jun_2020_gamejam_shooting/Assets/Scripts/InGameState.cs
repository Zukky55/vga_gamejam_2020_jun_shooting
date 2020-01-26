using UnityEngine;

namespace gamejam
{
    public class InGameState : MonoBehaviour
    {

        private void Awake()
        {

            GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, OnStateEnter);
            GameManager.Instance.Statemachine.SubscribeEvent(When.Exit, OnStateExit);
        }

        private void OnStateEnter(State obj)
        {
            if (!obj.Equals(State.InGame)) return;
        }

        private void OnStateExit(State obj)
        {
            if (!obj.Equals(State.InGame)) return;
        }
    }

}

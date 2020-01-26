using UnityEngine;

namespace gamejam
{
    public class ResultState : MonoBehaviour
    {

        [SerializeField]
        ResultUI resultUI;

        private void Start()
        {

            GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, OnStateEnter);
            GameManager.Instance.Statemachine.SubscribeEvent(When.Exit, OnStateExit);
        }

        private void OnStateEnter(State obj)
        {
            if (!obj.Equals(State.Result)) return;
            resultUI.Play(GameManager.Instance.Winer);
        }

        private void OnStateExit(State obj)
        {
            if (!obj.Equals(State.Result)) return;
        }
    }

}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            GameManager.Instance.Statemachine.SubscribeEvent(When.Stay, OnStateStay);
            resultUI.gameObject.SetActive(false);
        }

        private void OnStateStay(State obj)
        {
            if (!obj.Equals(State.Result)) return;
            if (Input.GetAxis("Sphere") != 0f)
            {
                SceneManager.LoadScene("Main", LoadSceneMode.Single);
            }
        }

        private void OnStateEnter(State obj)
        {
            if (!obj.Equals(State.Result)) return;
            resultUI.gameObject.SetActive(true);
            resultUI.Play(GameManager.Instance.Winer);
        }

        private void OnStateExit(State obj)
        {
            if (!obj.Equals(State.Result)) return;
        }
    }

}

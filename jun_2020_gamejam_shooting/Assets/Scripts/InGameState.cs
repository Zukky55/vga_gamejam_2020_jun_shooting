using System;
using UniRx.Async;
using UnityEngine;

namespace gamejam {
	public class InGameState : MonoBehaviour {
		public float ElapsedTime => elapsedTime - startTIme;

		float startTIme;
		float elapsedTime;
		private void Start() {
			GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, OnStateEnter);
			GameManager.Instance.Statemachine.SubscribeEvent(When.Exit, OnStateExit);
			GameManager.Instance.Statemachine.SubscribeEvent(When.Stay, OnStateStay);
		}

		private void OnStateStay(State obj) {
			if (!obj.Equals(State.InGame)) return;


		}

		private async void OnStateEnter(State obj) {
			if (!obj.Equals(State.InGame)) return;

			startTIme = elapsedTime = Time.timeSinceLevelLoad;

			while (obj.Equals(State.InGame)) {
				await UniTask.Delay(TimeSpan.FromSeconds(5));

				var go = Resources.Load("bom") as GameObject;
				go = Instantiate(go, new Vector3(UnityEngine.Random.Range(-8.3f,8.3f), UnityEngine.Random.Range(-3.3f, 5.3f), 0), Quaternion.identity);
				var bom = go.GetComponent<bom>();
			}
		}

		private void OnStateExit(State obj) {
			if (!obj.Equals(State.InGame)) return;
		}


	}

}

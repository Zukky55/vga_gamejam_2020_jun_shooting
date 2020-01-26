using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam {
	public class audio_se : MonoSingleton<audio_se> {

		[SerializeField]
		private AudioClip victry_se;
		[SerializeField]
		private AudioClip countDown_se;
		[SerializeField]
		private AudioClip damage_se;
		[SerializeField]
		private AudioClip startButton_se;
		[SerializeField]
		private AudioClip start_se;
		[SerializeField]
		private AudioClip button_se;
		[SerializeField]
		private AudioClip bullet_se;
		[SerializeField]
		private AudioClip roseBomb_se;
		AudioSource _audioSource;

		static audio_se instance;

		void Update() {
		}

		void Start() {
			_audioSource = GetComponent<AudioSource>();
			GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, victry_se_start);
			GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, victry_se_start);
		}

		void instance_start(State sample) {
			if (!sample.Equals(State.InGame)) return;
			instance = new audio_se();
		}

		void victry_se_start(State sample) {
			if (!sample.Equals(State.InGame)) return;
			_audioSource.PlayOneShot(victry_se);
		}


	}
}

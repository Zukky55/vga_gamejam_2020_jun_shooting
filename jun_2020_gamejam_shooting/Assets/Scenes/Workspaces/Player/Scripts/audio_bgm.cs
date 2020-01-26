using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam {
    public class audio_bgm : MonoBehaviour {
        [SerializeField]
        private AudioClip game_bgm;
        [SerializeField]
        private AudioClip title_bgm;
        AudioSource _audioSource;

        void Start() {
            _audioSource = GetComponent<AudioSource>();
            GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, title_bgm_start);
            GameManager.Instance.Statemachine.SubscribeEvent(When.Exit, title_bgm_end);
            GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, game_bgm_start);
            GameManager.Instance.Statemachine.SubscribeEvent(When.Exit, game_bgm_end);
        }

        void Update() {
        }

        void title_bgm_start(State sample) {
            if (!sample.Equals(State.Title)) return;
            _audioSource.clip = title_bgm;
            _audioSource.Play();

        }
        void title_bgm_end(State sample) {
            if (!sample.Equals(State.Title)) return;
            _audioSource.Stop();
        }

        void game_bgm_start(State sample) {
            if (!sample.Equals(State.InGame)) return;
            _audioSource.clip = game_bgm;
            _audioSource.Play();

        }
        void game_bgm_end(State sample) {
            if (!sample.Equals(State.InGame)) return;
            _audioSource.Stop();
        }
    }
}

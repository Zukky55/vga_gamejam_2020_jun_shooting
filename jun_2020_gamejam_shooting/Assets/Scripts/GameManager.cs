using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton   
        static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (!_instance)
                {
                    _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
                    if (!_instance)
                    {
                        throw new NullReferenceException(nameof(GameManager));
                    }
                }
                return _instance;
            }
        }
        #endregion

        List<Bullet> _bullets = new List<Bullet>();

        public void Initialize() => Statemachine.SetState(State.Initialize);
        public void CountDown() => Statemachine.SetState(State.CountDown);
        public void InGame() => Statemachine.SetState(State.InGame);
        public void Result() => Statemachine.SetState(State.Result);


        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            Statemachine.Update();

            if (Input.GetKeyDown(KeyCode.J)) CountDown();
            if (Input.GetKeyDown(KeyCode.K)) InGame();
            if (Input.GetKeyDown(KeyCode.L)) Result();

        }
    }
}
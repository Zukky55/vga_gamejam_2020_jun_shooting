﻿using UnityEngine;
using System.Collections;
using System;

namespace gamejam
{

    class Statemachine : MonoSingleton<Statemachine>
    {

        private State _currentState = State.Initialize;
        private bool _isFirst = false;
        private bool isfirstCalledExit = false;
        private bool isCalledEnter = false;

        public State CurrentState { get => _currentState; set => _currentState = value; }

        public event Action<State> OnStateEnter = s => Debug.Log($"Enter {s}");
        public event Action<State> OnStateStay = s => { };
        public event Action<State> OnStateExit = s => Debug.Log($"Exit {s}");

        public void SubscribeEvent(When when, Action<State> what)
        {
            switch (when)
            {
                case When.Enter:
                    OnStateEnter += what;
                    break;
                case When.Stay:
                    OnStateStay += what;
                    break;
                case When.Exit:
                    OnStateExit += what;
                    break;
                default:
                    break;
            }
        }

       public void SetState(State next)
        {
            if (isfirstCalledExit)
            {
                isfirstCalledExit = false;
            }
            else
            {
                OnStateExit?.Invoke(_currentState);
            }
            _currentState = next;
            isCalledEnter = false;
        }

        void Update()
        {
            if (!isCalledEnter)
            {
                OnStateEnter?.Invoke(_currentState);
                isCalledEnter = true;
            }
            else
            {
                OnStateStay?.Invoke(_currentState);
            }
        }
    }
    public enum State
    {
        Initialize,
        Title,
        CountDown,
        InGame,
        Result,
        GameEnd,
    }
    public enum When
    {
        Enter,
        Stay,
        Exit,
    }
}

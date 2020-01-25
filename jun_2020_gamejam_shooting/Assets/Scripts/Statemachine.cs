using UnityEngine;
using System.Collections;
using System;

namespace gamejam
{

    class Statemachine
    {
        #region Singleton   
        static Statemachine _instance = new Statemachine();
        #endregion

        private State _currentState = State.Initialize;
        private bool _isFirst = false;
        private bool isfirstCalledExit = false;
        private bool isCalledEnter = false;

        public State CurrentState { get => _instance._currentState; set => _instance._currentState = value; }

        public event Action<State> OnStateEnter = s => Debug.Log($"Enter {s}");
        public event Action<State> OnStateStay = s => Debug.Log($"Stay {s}");
        public event Action<State> OnStateExit = s => Debug.Log($"Exit {s}");

        public static void SetState(State next) => _instance.setState(next);
        public static void Update() => _instance.update();
        public static void SubscribeEvent(When when, Action<State> what) => _instance.subscribeEvent(when, what);

        void subscribeEvent(When when, Action<State> what)
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

        void setState(State next)
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

        void update()
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
        CountDown,
        InGame,
        Result,
    }
    public enum When
    {
        Enter,
        Stay,
        Exit,
    }
}

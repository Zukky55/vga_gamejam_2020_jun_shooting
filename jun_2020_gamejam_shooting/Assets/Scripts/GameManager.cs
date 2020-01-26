using System;
using System.Collections;
using System.Collections.Generic;

namespace gamejam
{
    public class GameManager : MonoSingleton<GameManager>
    {
        Statemachine statemachine;
        ResourceManager resourceManager;

        OwnerType winer = OwnerType.None;

        internal Statemachine Statemachine => statemachine;
        internal ResourceManager ResourceManager => resourceManager;

        public void SetWiner(OwnerType winer)
        {
            this.winer = winer;
            statemachine.SetState(State.Result);
        }

        private void OnStateEnter(State obj)
        {
            if (obj.Equals(State.Result)) return;
        }

        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
            Instance.Statemachine.SetState(State.Initialize);
        }

        private void Initialize()
        {
            statemachine = Statemachine.Instance;
            resourceManager = ResourceManager.Instance;
        }
    }
}
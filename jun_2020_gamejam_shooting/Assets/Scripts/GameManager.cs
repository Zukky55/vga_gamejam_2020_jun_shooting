using System.Collections;
using System.Collections.Generic;

namespace gamejam
{
    public class GameManager : MonoSingleton<GameManager>
    {
        Statemachine _statemachine;
        ResourceManager _resourceManager;

        List<Bullet> player1Bullets = new List<Bullet>();
        List<Bullet> plaeyr2Bullets = new List<Bullet>();

        internal Statemachine Statemachine => _statemachine;
        internal ResourceManager ResourceManager => _resourceManager;

        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
            Statemachine.Initialize();
        }

        private void Initialize()
        {
            _statemachine = Statemachine.Instance;
            _resourceManager = ResourceManager.Instance;
        }
    }
}
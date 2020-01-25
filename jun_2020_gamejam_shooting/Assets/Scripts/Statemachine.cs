using UnityEngine;
using System.Collections;
using System;

namespace gamejam
{

    public class Statemachine : MonoBehaviour
    {
        #region Singleton   
        static Statemachine _instance;
        public static Statemachine Instance
        {
            get
            {
                if (!_instance)
                {
                    _instance = FindObjectOfType(typeof(Statemachine)) as Statemachine;
                    if (!_instance)
                    {
                        throw new NullReferenceException(nameof(Statemachine));
                    }
                }
                return _instance;
            }
        }
        #endregion


    }
    public enum State
    {
        Initialize,
        CountDown,
        InGame,
        Result,
    }
}

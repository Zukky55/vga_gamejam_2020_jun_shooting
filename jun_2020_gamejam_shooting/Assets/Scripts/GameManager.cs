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
    }
}
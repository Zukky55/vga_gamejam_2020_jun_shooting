using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam {

    public class bom : MonoBehaviour ,IOnwer

    {
        [SerializeField]
        private int bullet_value = 30;
        [SerializeField]
        private int hp = 10;
        [SerializeField]
        private OwnerType _type;

        ResourceManager rm;

        public int HP => hp;

        public OwnerType Type => _type;

        private void Awake()
        {
            rm = GameManager.Instance.ResourceManager;
        }
        private void Start() {
            GameManager.Instance.Statemachine.SubscribeEvent(When.Stay, OnStateStay);
        }

        private void OnStateStay(State obj) {
            if (!obj.Equals(State.InGame)) return;

        }

        void Update() {
 
        }


        public void TakeDamage(int damage) {
            --hp;
        }

        public void Destroy() {
            for (int i = 0; i < bullet_value; ++i) {
                var b = ResourceManager.GetBullet(_type);
                b.Shot(transform.position, new Vector3(UnityEngine.Random.Range(-4f, 4f), UnityEngine.Random.Range(-4f, 4f), 0) * 1.5f);
            }
            gameObject.SetActive(false);
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam
{
    class ResourceManager : MonoSingleton<ResourceManager>
    {
        const int bulletResourceAmount = 300;

        List<Bullet> player1Bullets = new List<Bullet>();
        List<Bullet> player2Bullets = new List<Bullet>();
        bool isInitialized = false;

        public List<Bullet> Player1Bullets { get => player1Bullets; set => player1Bullets = value; }
        public List<Bullet> Playr2Bullets { get => player2Bullets; set => player2Bullets = value; }

        private void Awake()
        {
            GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, OnInitializeEnter);
        }

        /// <summary>
        /// 条件に応じて弾の参照取得
        /// </summary>
        /// <param name="type">弾の種類</param>
        /// <param name="isUsing">使用中の弾かどうか</param>
        /// <returns></returns>
        public Bullet GetBullet(OwnerType type, bool isUsing)
        {
            if (!isInitialized) throw new Exception("初期化されてへんで");
            switch (type)
            {
                case OwnerType.Player1:
                    return Player1Bullets.Find(b => b.IsUsing.Equals(isUsing));
                case OwnerType.Player2:
                    return player2Bullets.Find(b => b.IsUsing.Equals(isUsing));
                case OwnerType.Other:
                default:
                    throw new ArgumentException();
            }
        }

        void OnInitializeEnter(State state)
        {
            if (!state.Equals(State.Initialize)) return;
            Initialize();
        }

        void Initialize()
        {
            for (int i = 0; i < bulletResourceAmount; ++i)
            {
                var go = Resources.Load("bullet_pink") as GameObject;
                go = Instantiate(go, new Vector3(100f, 100f, -100f), Quaternion.identity);
                var bullet = go.GetComponent<Bullet>();
                bullet.Deactivate(false);
                player1Bullets.Add(bullet);

                go = Resources.Load("bullet_blue") as GameObject;
                go = Instantiate(go, new Vector3(100f, 100f, -100f), Quaternion.identity);
                bullet = go.GetComponent<Bullet>();
                bullet.Deactivate(false);
                player2Bullets.Add(bullet);
            }
            isInitialized = true;
        }
    }
}
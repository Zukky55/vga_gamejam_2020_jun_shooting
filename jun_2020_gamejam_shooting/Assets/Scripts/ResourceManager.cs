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
        List<Bullet> bombBullets = new List<Bullet>();
        bool isInitialized = false;

        public bool IsInitialized { get => isInitialized; set => isInitialized = value; }

        private void Start()
        {
            GameManager.Instance.Statemachine.SubscribeEvent(When.Enter, OnInitializeEnter);
        }

        public static Bullet GetBullet(OwnerType type, bool isUsing = false) => m_instance.getBullet(type, isUsing);

        /// <summary>
        /// 条件に応じて弾の参照取得
        /// </summary>
        /// <param name="type">弾の種類</param>
        /// <param name="isUsing">使用中の弾かどうか</param>
        /// <returns></returns>
        Bullet getBullet(OwnerType type, bool isUsing)
        {
            if (!isInitialized) throw new Exception("初期化されてへんで");
            switch (type)
            {
                case OwnerType.player1:
                    return player1Bullets.Find(b => b.IsUsing.Equals(isUsing));
                case OwnerType.player2:
                    return player2Bullets.Find(b => b.IsUsing.Equals(isUsing));
                case OwnerType.Bomb:
                    return bombBullets.Find(b => b.IsUsing.Equals(isUsing));
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
                bullet.Deactivate();
                player1Bullets.Add(bullet);

                go = Resources.Load("bullet_blue") as GameObject;
                go = Instantiate(go, new Vector3(100f, 100f, -100f), Quaternion.identity);
                bullet = go.GetComponent<Bullet>();
                bullet.Deactivate();
                player2Bullets.Add(bullet);

                go = Resources.Load("bullet_bomb") as GameObject;
                go = Instantiate(go, new Vector3(100f, 100f, -100f), Quaternion.identity);
                bullet = go.GetComponent<Bullet>();
                bullet.Deactivate();
                bombBullets.Add(bullet);

            }
            isInitialized = true;
        }
    }
}
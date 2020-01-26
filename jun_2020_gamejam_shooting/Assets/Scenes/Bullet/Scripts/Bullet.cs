using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace gamejam
{

    [RequireComponent(typeof(Rigidbody), typeof(Collider2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        Rigidbody2D rb2d;

        [SerializeField]
        BulletParam param;

        bool isInitialized = false;
        bool isUsing = false;
        Vector3 velocity;
        Vector3 spawnPos;

        const float destroyBoundary = 1000f;

        public bool IsUsing { get => isUsing; set => isUsing = value; }
        public BulletParam Param { get => param; set => param = value; }

        private void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => isUsing && isInitialized)
                .Subscribe(_ =>
                {
                    Move();
                })
                .AddTo(this);

            this.UpdateAsObservable()
                .Where(_ => (transform.position - spawnPos).sqrMagnitude > destroyBoundary)
                .Subscribe(_ =>
                {
                    Deactivate();
                })
                .AddTo(this);
        }


        void Move()
        {
            rb2d.velocity = velocity;
            transform.up = velocity;
        }

        public void Shot(Vector3 spawnPos, Vector3 velocity)
        {
            this.spawnPos = spawnPos;
            transform.position = spawnPos;
            if (!gameObject.activeSelf) gameObject.SetActive(true);
            this.velocity = velocity;
            isInitialized = true;
            isUsing = true;
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            isInitialized = false;
            isUsing = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log($"collied name is {gameObject.name}");
            IOnwer owner = null;
            if (collision.gameObject.TryGetComponent(out owner))
            {
                if (!owner.Type.Equals(param.Type)|| owner.Type.Equals(OwnerType.Bomb))
                {
                    owner.TakeDamage(param.Atatck);
                    if (owner.HP <= 0)
                    {
                        owner.Destroy();
                    }
                    Deactivate();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log($"triggered {collision.gameObject.name}");
        }

    }
}
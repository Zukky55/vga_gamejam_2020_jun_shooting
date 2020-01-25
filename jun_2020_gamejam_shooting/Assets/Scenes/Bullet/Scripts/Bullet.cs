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
        Rigidbody2D _rb2d;

        BulletParam _param = null;
        bool _isInitialized = false;
        bool _isUsing = false;

        public static void InstantiateShot(Vector3 spawnPos, Vector3 velocity)
        {
            var go = Resources.Load("Bullet") as GameObject;
            go = Instantiate(go, spawnPos, Quaternion.identity);
            var bullet = go.GetComponent<Bullet>();
            bullet.Shot(velocity);
        }

        private void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => _isUsing && _isInitialized)
                .Do(_ => Debug.Log($"{this.name} is Subscribed."))
                .Subscribe(_ =>
                {
                    Move();
                })
                .AddTo(this);
        }

        public void SetUsing(bool isUse)
        {
            gameObject.SetActive(isUse);
            _isUsing = isUse;
        }

        public void Shot(BulletParam param)
        {
            if (!gameObject.activeSelf) gameObject.SetActive(true);
            _param = Instantiate(param);
            _isInitialized = true;
            _isUsing = true;
        }

        public void Shot(Vector3 velocity)
        {
            if (!gameObject.activeSelf) gameObject.SetActive(true);
            _param = new BulletParam(velocity);
            _isInitialized = true;
            _isUsing = true;
        }

        void Move()
        {
            _rb2d.velocity = _param.Velocity;
        }

        public void Diactivate(bool isClearParam)
        {
            gameObject.SetActive(false);
            if (isClearParam) clearParam();
            _isUsing = false;
        }

        void clearParam()
        {
            _param = null;
            _isInitialized = false;
        }

        public enum BulletTag
        {
            Player1,
            Player2,
            Enemy,
        }
    }
}
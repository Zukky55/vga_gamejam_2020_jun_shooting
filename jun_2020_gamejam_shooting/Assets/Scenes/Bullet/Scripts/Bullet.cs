using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[RequireComponent(typeof(Rigidbody), typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    BulletParam _param = null;
    bool _isInitialized = false;
    bool _isUsing = false;

    public void Initialize(BulletParam param)
    {
        _param = param;
        _isInitialized = true;
    }

    private void Shot()
    {
        if (!_isInitialized) return;
        
    }

    public class BulletParam
    {
        public Vector3 Velocity;
    }
    public enum BulletTag
    {
        Player1,
        Player2,
        Enemy,
    }
}

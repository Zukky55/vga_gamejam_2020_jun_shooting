using UnityEngine;

namespace gamejam
{
    public class BulletParam : ScriptableObject
    {
        private Vector3 _velocity;
        BulletType _type;
        public Vector3 Velocity { get => _velocity; set => _velocity = value; }
        public BulletType Type { get => _type; set => _type = value; }
        public BulletParam() { }
        public BulletParam(Vector3 velocity)
        {
            _velocity = velocity;
        }
    }
    public enum BulletType
    {
        Player1,
        Player2,
        Enemy,
    }
}
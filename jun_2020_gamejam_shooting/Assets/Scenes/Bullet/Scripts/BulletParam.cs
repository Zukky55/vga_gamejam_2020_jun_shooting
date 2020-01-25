using UnityEngine;

namespace gamejam
{
    public class BulletParam : ScriptableObject
    {
        private Vector3 _velocity;
        public Vector3 Velocity { get => _velocity; set => _velocity = value; }



        public BulletParam() { }
        public BulletParam(Vector3 velocity)
        {
            _velocity = velocity;
        }
    }
}
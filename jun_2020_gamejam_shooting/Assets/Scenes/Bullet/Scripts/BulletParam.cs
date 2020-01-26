using System;
using UnityEngine;

namespace gamejam
{
    [Serializable]
    public class BulletParam:IOrganized
    {
        [SerializeField]
        const int _atatck = 1;
        [SerializeField]
        OwnerType _type;

        public OwnerType Type { get => _type; set => _type = value; }
        public int Atatck => _atatck;

        public BulletParam(OwnerType type)
        {
            _type = type;
        }
    }
}
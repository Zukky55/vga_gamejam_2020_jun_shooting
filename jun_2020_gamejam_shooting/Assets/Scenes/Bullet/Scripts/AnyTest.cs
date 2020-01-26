using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam
{

    public class AnyTest : MonoBehaviour
    {

        private void Update()
        {
            var vec = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0f);
            var b = ResourceManager.GetBullet(OwnerType.Player2);
            var a = ResourceManager.GetBullet(OwnerType.Player1);
            b.Shot(transform.position, vec);
            a.Shot(transform.position, vec);
        }
    }
}
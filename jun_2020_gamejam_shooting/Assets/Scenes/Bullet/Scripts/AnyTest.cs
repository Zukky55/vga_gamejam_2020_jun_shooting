using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam
{

    public class AnyTest : MonoBehaviour
    {

        private void Update()
        {
                var rm = GameManager.Instance.ResourceManager;
                var vec = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10),0f);
                var b = rm.GetBullet(OwnerType.Player2, false);
                var a = rm.GetBullet(OwnerType.Player1, false);
            b.Shot(transform.position,vec);
            a.Shot(transform.position,vec);
        }
    }
}
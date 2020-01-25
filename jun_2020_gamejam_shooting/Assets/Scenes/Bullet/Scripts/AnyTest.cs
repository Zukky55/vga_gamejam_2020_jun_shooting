using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam
{

    public class AnyTest : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var vel = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
                Bullet.InstantiateShot(transform.position,vel);
            }
        }
    }
}
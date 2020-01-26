using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam {

    public class bom : MonoBehaviour 

    {
        [SerializeField]
        private int bullet_value = 30;
        [SerializeField]
        private int hp = 10;

        ResourceManager rm;

        private void Awake()
        {
            rm = GameManager.Instance.ResourceManager;
        }

        void Update() {
            if(hp == 0) {
                for (int i = 0; i < bullet_value; ++i) {
                    //Bullet.InstantiateShot(this.transform.position, new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0) * 1.5f);
                }
                gameObject.SetActive(false);
            }

        }

        void OnTriggerEnter2D(Collider2D other) {
            Bullet b = other.GetComponent<Bullet>();
            //b.Deactivate(true);
            hp -= 1;
            
        }

    }
}

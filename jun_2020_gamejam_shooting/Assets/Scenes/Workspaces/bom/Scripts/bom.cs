using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam {

    public class bom : MonoBehaviour {
        [SerializeField]
        private int hp = 10;

        void Start() {

        }

        void Update() {
            if(hp == 0) {
                gameObject.SetActive(false);
            }

        }

        void OnTriggerEnter2D(Collider2D other) {
            Bullet b = other.GetComponent<Bullet>();
            b.Diactivate(true);
            hp -= 1;
            
        }

    }
}

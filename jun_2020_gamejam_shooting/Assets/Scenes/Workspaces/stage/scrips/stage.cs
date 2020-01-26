using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam {

    public class stage : MonoBehaviour {
        void Start() {

        }

        void Update() {

        }

        void OnTriggerExit2D(Collider2D other) {
            if (other.gameObject.CompareTag("Player")) {
                other.gameObject.SetActive(false);
            }
            if (other.gameObject.CompareTag("Bullet")) {
                other.gameObject.SetActive(false);
            }

            //Bullet b = other.GetComponent<Bullet>();
            //b.Diactivate(true);
            //hp -= 1;

        }

    }
}

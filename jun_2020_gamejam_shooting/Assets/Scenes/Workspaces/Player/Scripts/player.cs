using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam {

	public class player : MonoBehaviour {
		[SerializeField]
		private float spead = 0.1f;
		[SerializeField]
		Rigidbody2D rb2d;

		public float Horizontal => Input.GetAxis("Horizontal");
		public float Vertical => Input.GetAxis("Vertical");
		public Vector3 Velocity => new Vector3(Horizontal * spead, Vertical * spead, 0f);

		void Start() {
			rb2d = GetComponent<Rigidbody2D>();
		}

		void Update() {
			if (Velocity != Vector3.zero) {
				Move();
			}
		}

		private void Move() {
			//transform.position += Velocity;
			rb2d.transform.position += Velocity;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam {

	public class player : MonoBehaviour {
		[SerializeField]
		private int hp = 10;
		[SerializeField]
		private float reload_speed = 2;
		[SerializeField]
		private string player_mode = "player1";
		[SerializeField]
		private float bullet_speed = 0.1f;
		[SerializeField]
		private float speed = 0.1f;
		[SerializeField]
		private Rigidbody2D rb2d;
		[SerializeField]
		private Rigidbody2D aim_rb2d;
		[SerializeField]
		private GameObject aim;
		[SerializeField]
		private GameObject life;
		[SerializeField]
		private GameObject damage;

		public float Horizontal => Input.GetAxis("Horizontal_" + player_mode);
		public float Vertical => Input.GetAxis("Vertical_" + player_mode);
		public Vector3 Velocity => new Vector3(Horizontal, Vertical, 0f);

		public float AimHorizontal => Input.GetAxis("AimHorizontal_" + player_mode);
		public float AimVertical => Input.GetAxis("AimVertical_" + player_mode);
		public Vector3 AimVelocity => new Vector3(AimHorizontal * bullet_speed, AimVertical * bullet_speed, 0f);

		private float bullet_wait_counter = 0;
		private bool bullet_wait = false;

		void Start() {
			rb2d = GetComponent<Rigidbody2D>();
			aim_rb2d = aim.GetComponent<Rigidbody2D>();
		}

		void Update() {

			if (Velocity != Vector3.zero) {
				Move();
			}

			if (AimVelocity != Vector3.zero) {
				aim_rb2d.transform.position = (AimVelocity + transform.position);
			}
			else aim_rb2d.transform.position = transform.position;


			if (Input.GetAxis("shot_" + player_mode) != 0) {
				if (bullet_wait == false) {
					Bullet.InstantiateShot(this.transform.position, AimVelocity);
					//TODO
					bullet_wait = true;
				}
			}
			if (bullet_wait == true) {
				bullet_wait_counter += Time.deltaTime;
				if (bullet_wait_counter >= reload_speed) {
					bullet_wait = false;
					bullet_wait_counter = 0;
				}
			}

			if (hp == 0) {
				gameObject.SetActive(false);
			}
		}

		void OnTriggerEnter2D(Collider2D other) {
			Bullet b = other.GetComponent<Bullet>();
			//TODO
			b.Diactivate(true);
			hp -= 1;
		}

		private void Move() {
			rb2d.transform.position += Velocity * speed;
		}
	}
}

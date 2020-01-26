using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam {

	public class player : MonoBehaviour, IOnwer {
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
		private GameObject damage_bar;
		[SerializeField]
		private GameObject hp_bar;
		[SerializeField]
		private OwnerType _type;


		public float Horizontal => Input.GetAxis("Horizontal_" + player_mode);
		public float Vertical => Input.GetAxis("Vertical_" + player_mode);
		public Vector3 Velocity => new Vector3(Horizontal, Vertical, 0f);

		public float AimHorizontal => Input.GetAxisRaw("AimHorizontal_" + player_mode);
		public float AimVertical => Input.GetAxisRaw("AimVertical_" + player_mode);
		public Vector3 AimVelocity => new Vector3(AimHorizontal, AimVertical, 0f);
		public int HP => hp;
		public OwnerType Type => _type;

		private float bullet_wait_counter = 0;
		private bool bullet_wait = false;

		[SerializeField]
		private float offset ;

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
			

			OwnerType mode = OwnerType.Other;
			if (Input.GetAxis("shot_" + player_mode) != 0) {
				if (AimVelocity != Vector3.zero) {
					if (bullet_wait == false) {
						if (player_mode == "player1") mode = OwnerType.Player1;
						else if (player_mode == "player2") mode = OwnerType.Player2;
						var b = ResourceManager.GetBullet(mode);
						b.Shot(transform.position + AimVelocity.normalized * offset, AimVelocity.normalized * bullet_speed);
						bullet_wait = true;
					}
				}
			}
			if (bullet_wait == true) {
				bullet_wait_counter += Time.deltaTime;
				if (bullet_wait_counter >= reload_speed) {
					bullet_wait = false;
					bullet_wait_counter = 0;
				}
			}

			//hp_bar.transform.position = transform.position;
			//damage_bar.transform.position = transform.position;

		}



		private void Move() {
			rb2d.transform.position += Velocity * speed;
		}

		public void TakeDamage(int damage) {
			--hp;
		}

		public void Destroy() {
			// tds
			// TODO 負けたtypeを入れる
			Destroy(gameObject);
		}
	}
}

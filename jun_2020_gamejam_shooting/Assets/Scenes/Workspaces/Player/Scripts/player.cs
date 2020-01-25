using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam {

	public class player : MonoBehaviour {
		[SerializeField]
		private string player_mode = "player1";
		[SerializeField]
		private float bullet_spead = 0.1f;
		[SerializeField]
		private float spead = 0.1f;
		[SerializeField]
		Rigidbody2D rb2d;

		public float Horizontal => Input.GetAxis("Horizontal_" + player_mode);
		public float Vertical => Input.GetAxis("Vertical_" + player_mode);
		public Vector3 Velocity => new Vector3(Horizontal * spead, Vertical * spead, 0f);

		public float AimHorizontal => Input.GetAxis("AimHorizontal_" + player_mode);
		public float AimVertical => Input.GetAxis("AimVertical_" + player_mode);
		public Vector3 AimVelocity => new Vector3(AimHorizontal * bullet_spead, AimVertical * bullet_spead, 0f);

		private int bullet_wait_counter = 0;
		private bool bullet_wait = false;

		void Start() {
			rb2d = GetComponent<Rigidbody2D>();
		}

		void Update() {
			Debug.Log($"vel of  {name} = {Velocity}");
			if (Velocity != Vector3.zero) {
				Move();
			}

			if (Input.GetAxis("shot_" + player_mode) != 0) {
				if (!bullet_wait) {
					Bullet.InstantiateShot(this.transform.position, AimVelocity);
					bullet_wait = true;
				}
				else {
					bullet_wait_counter++;
					if (bullet_wait_counter <= 20) bullet_wait = false;
				}
			}
		}

		private void Move() {
			//transform.position += Velocity;
			rb2d.transform.position += Velocity;
			//rb2d.velocity = Velocity;

		}
	}
}

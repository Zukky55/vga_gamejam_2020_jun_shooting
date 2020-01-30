using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam
{

    public class player : MonoBehaviour, IOnwer
    {
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
        [SerializeField]
        private AudioClip shot_se;
        AudioSource _audioSource;



        public float Horizontal => Input.GetAxis("Horizontal_" + player_mode);
        public float Vertical => Input.GetAxis("Vertical_" + player_mode);
        public Vector3 Velocity => new Vector3(Horizontal, Vertical, 0f);

        public float AimHorizontal => Input.GetAxis("AimHorizontal_" + player_mode);
        public float AimVertical => Input.GetAxis("AimVertical_" + player_mode);
        public Vector3 AimVelocity => new Vector3(AimHorizontal, AimVertical, 0f);
        public int HP => hp;
        public OwnerType Type => _type;

        private float bullet_wait_counter = 0;
        private bool bullet_wait = false;

        [SerializeField]
        private float offset;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            aim_rb2d = aim.GetComponent<Rigidbody2D>();
            _audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            if (!GameManager.Instance.Statemachine.CurrentState.Equals(State.InGame)) return;

            Debug.Log($"{player_mode} vel = {AimVelocity}");
            if (Velocity != Vector3.zero)
            {
                Move();
            }

            if (AimVelocity != Vector3.zero)
            {
                aim.transform.position = (AimVelocity.normalized + transform.position);
            }


            OwnerType mode = OwnerType.Other;
            if (Input.GetAxis("shot_" + player_mode) != 0)
            {
                if (bullet_wait == false)
                {
                    _audioSource.PlayOneShot(shot_se);
                    if (player_mode == "player1") mode = OwnerType.player1;
                    else if (player_mode == "player2") mode = OwnerType.player2;
                    var b = ResourceManager.GetBullet(mode);
                    b.Shot(aim.transform.position, (aim.transform.position - transform.position) * bullet_speed);
                    bullet_wait = true;
                }
            }
            if (bullet_wait == true)
            {
                bullet_wait_counter += Time.deltaTime;
                if (bullet_wait_counter >= reload_speed)
                {
                    bullet_wait = false;
                    bullet_wait_counter = 0;
                }
            }

            //hp_bar.transform.position = transform.position;
            //damage_bar.transform.position = transform.position;

        }



        private void Move()
        {
            rb2d.transform.position += Velocity * speed;
            if (rb2d.transform.position.x <= -8.3) rb2d.transform.position -= new Vector3(-0.1f, 0, 0);
            if (rb2d.transform.position.x >= 8.3) rb2d.transform.position -= new Vector3(0.1f, 0, 0);
            if (rb2d.transform.position.y <= 5.3) rb2d.transform.position -= new Vector3(0, -0.1f, 0);
            if (rb2d.transform.position.y >= -3.3) rb2d.transform.position -= new Vector3(0, 0.1f, 0);
        }

        public void TakeDamage(int damage)
        {
            --hp;
        }

        public void Destroy()
        {
            OwnerType mode = OwnerType.None;
            if (player_mode == "player1")
            {
                mode = OwnerType.player2;
            }
            else
            {
                mode = OwnerType.player1;
            }
            GameManager.Instance.Result(mode);
            Destroy(gameObject);
        }
    }
}

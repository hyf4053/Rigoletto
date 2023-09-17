using UnityEngine;
using UnityEngine.Serialization;

namespace Actors.Character
{
    public class Character2DController : MonoBehaviour
    {
        public Animator characterAnimator;
        public SpriteRenderer SpRenderer;
        public Rigidbody2D Rigidbody2D;

        private static readonly int isMove = Animator.StringToHash("isMove");

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.A))
            {
                characterAnimator.SetBool(isMove,true);
                CharacterMove();
            }

            if (!Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.A))
            {
                characterAnimator.SetBool(isMove,false);
                Rigidbody2D.velocity = Vector2.zero;
            }

            if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S))
            {
                characterAnimator.SetBool(isMove,true);
                CharacterMove();
            }
        }

        void CharacterMove()
        {
            if (Input.GetKey(KeyCode.D))
            {
                SpRenderer.flipX = false;
               // Rigidbody2D.velocity = new Vector2(1, 0);
                transform.position += new Vector3(0.002f, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                SpRenderer.flipX = true;
               // Rigidbody2D.velocity = new Vector2(-1, 0);
                transform.position += new Vector3(-0.002f, 0, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                //SpRenderer.flipX = true;
                transform.position += new Vector3(0, 0, 0.002f);
            }
            if (Input.GetKey(KeyCode.S))
            {
               // SpRenderer.flipX = true;
                transform.position += new Vector3(0, 0, -0.002f);
            }
        }
    }
}

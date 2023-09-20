using GameFramework;
using UnityEngine;
using UnityEngine.Serialization;

namespace Actors.Character
{
    public class Character2DController : MonoBehaviour
    {
        public Animator characterAnimator;
        public SpriteRenderer SpRenderer;
        public Rigidbody2D Rigidbody2D;
        public BaseCharacter BaseCharacter;
        public float speed;

        public PlayMakerFSM fsm;

        public static readonly int isMove = Animator.StringToHash("isMove");

        // Start is called before the first frame update
        void Start()
        {
            BaseCharacter = GetComponentInChildren<BaseCharacter>();
            //fsm.GetComponent<PlayMakerFSM>();
        }

        // Update is called once per frame

        public void ResetAnimation()
        {
            characterAnimator.SetBool(isMove,false);
        }

        public void MoveLeft()
        {
            characterAnimator.SetBool(isMove,true);
            SpRenderer.flipX = true;
            transform.position += new Vector3(-speed, 0, 0);
        }

        public void MoveRight()
        {
            characterAnimator.SetBool(isMove,true);
            SpRenderer.flipX = false;
            transform.position += new Vector3(speed, 0, 0);
        }

        public void MoveUp()
        {
            characterAnimator.SetBool(isMove,true);
            transform.position += new Vector3(0, 0, speed);
        }

        public void MoveDown()
        {
            characterAnimator.SetBool(isMove,true);
            transform.position += new Vector3(0, 0, -speed);
        }

        public void PlayMove()
        {
            characterAnimator.SetBool(isMove,true);
        }
    }
}

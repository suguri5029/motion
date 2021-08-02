using UnityEngine;

public enum TransitionParameter
{
    Move,
    Jump,
    ForceTransition,
    Grounded,
    Sit,
    StandUp,
    Recover
}

public class CharacterControl : MonoBehaviour
{
    public Animator animator;
    public bool MoveRight;
    public bool MoveLeft;
    public bool Jump;
    public bool Sit;
    public bool StandUp;

    private Rigidbody rigid;
    public Rigidbody RIGID_BODY
    {
        get
        {
            if (rigid == null)
            {
                rigid = GetComponent<Rigidbody>();
            }
            return rigid;
        }
    }

    private void Update()
    {
        Debug.Log(Time.time);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rigid.AddForce(Vector3.up * rigid.velocity.y);
        }
    }*/
}

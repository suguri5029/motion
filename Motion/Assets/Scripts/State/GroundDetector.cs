using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "AbilityData/GroundDetector")]
public class GroundDetector : StateData
{

    public float Distance;
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        animator.SetBool(TransitionParameter.Grounded.ToString(), IsGrounded(control));
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    bool IsGrounded(CharacterControl control)
    {
        if (control.RIGID_BODY.velocity.y > -0.01f && control.RIGID_BODY.velocity.y <= 0f)
        {
            return true;
        }
        Debug.DrawRay(control.transform.position, Vector3.down * 0.7f, Color.yellow);
        RaycastHit hitInfo;
        if (Physics.Raycast(control.transform.position, Vector3.down, out hitInfo, Distance))
        {
            return true;
        }

        return false;
    }
}

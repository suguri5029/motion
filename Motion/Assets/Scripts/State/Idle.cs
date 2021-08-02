using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "AbilityData/Idle")]
public class Idle : StateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.SetBool(TransitionParameter.StandUp.ToString(), false);
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        animator.SetBool(TransitionParameter.Recover.ToString(), false);

        if (control.Jump)
        {
            animator.SetBool(TransitionParameter.Jump.ToString(), true);
        }

        if (control.Sit)
        {
            animator.SetBool(TransitionParameter.Sit.ToString(), true);
        }

        if (control.MoveRight)
        {
            animator.SetBool(TransitionParameter.Move.ToString(), true);
        }

        if (control.MoveLeft)
        {
            animator.SetBool(TransitionParameter.Move.ToString(), true);
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}

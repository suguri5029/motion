using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "AbilityData/MoveForward")]
public class MoveForward : StateData
{
    public float Speed = 1f;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        if (control.Jump)
        {
            animator.SetBool(TransitionParameter.Jump.ToString(), true);
        }

        if (!(control.MoveRight ^ control.MoveLeft))
        {
            animator.SetBool(TransitionParameter.Move.ToString(), false);
            return;
        }
        else
        {
            control.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            if (control.MoveRight)
            {
                control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            if (control.MoveLeft)
            {
                control.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}

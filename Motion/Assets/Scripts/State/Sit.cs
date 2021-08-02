using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "AbilityData/Sit")]
public class Sit : StateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        if (control.StandUp)
        {
            if (stateInfo.normalizedTime >= 0.95f)
            {
                animator.SetBool(TransitionParameter.StandUp.ToString(), true);
            }
            else
            {
                animator.SetBool(TransitionParameter.Recover.ToString(), true);
            }
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}

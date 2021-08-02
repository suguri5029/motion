using System.Collections.Generic;
using UnityEngine;

public class CharacterState : StateMachineBehaviour
{
    private CharacterControl characterControl;
    public List<StateData> ListAbilityData = new List<StateData>();

    public CharacterControl GetCharacterControl(Animator animator)
    {
        if (characterControl == null)
        {
            characterControl = animator.GetComponentInParent<CharacterControl>();
        }
        return characterControl;
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (StateData data in ListAbilityData)
        {
            data.OnEnter(this, animator, stateInfo);
        }
    }

    public void UpdateAll(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        foreach (StateData data in ListAbilityData)
        {
            data.UpdateAbility(characterState, animator, stateInfo);
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        UpdateAll(this, animator, stateInfo);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (StateData data in ListAbilityData)
        {
            data.OnExit(this, animator, stateInfo);
        }
    }
}

using UnityEngine;

public class ManualInput : MonoBehaviour
{
    private CharacterControl characterControl;

    void Awake()
    {
        characterControl = this.gameObject.GetComponent<CharacterControl>();
    }

    void Update()
    {
        characterControl.MoveRight = VirtualInputManager.Instance.MoveRight;
        characterControl.MoveLeft = VirtualInputManager.Instance.MoveLeft;
        characterControl.Jump = VirtualInputManager.Instance.Jump;
        characterControl.Sit = VirtualInputManager.Instance.Sit;
        characterControl.StandUp = VirtualInputManager.Instance.StandUp;
    }
}

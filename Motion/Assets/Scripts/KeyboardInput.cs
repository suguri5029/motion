using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    void Update()
    {
        VirtualInputManager.Instance.MoveRight = Input.GetKey(KeyCode.D);
        VirtualInputManager.Instance.MoveLeft = Input.GetKey(KeyCode.A);
        VirtualInputManager.Instance.Jump = Input.GetKey(KeyCode.Space);
        VirtualInputManager.Instance.Sit = Input.GetKey(KeyCode.S);
        VirtualInputManager.Instance.StandUp = Input.GetKey(KeyCode.W);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReaderController : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterJump characterJump;

    public void SetMovementValue(InputAction.CallbackContext inputContext)
    {
        Vector2 inputValue = inputContext.ReadValue<Vector2>();
        characterMovement.SetDirection(inputValue);
    }

    public void RequestJump(InputAction.CallbackContext inputContext)
    {
        if (inputContext.started)
        {
            if (characterJump == null)
            {
                Debug.LogError($"{name} character jump is null");
                return;
            }
            //characterJump.Jump();
        }
    }
}

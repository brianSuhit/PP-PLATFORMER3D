using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReaderController : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;

    public void SetMovementValue(InputAction.CallbackContext inputContext)
    {
        Vector2 inputValue = inputContext.ReadValue<Vector2>();
        characterMovement.SetDirection(inputValue);

        Debug.Log($"{gameObject.name}: Event risen. Value: {inputValue}");
    }
}

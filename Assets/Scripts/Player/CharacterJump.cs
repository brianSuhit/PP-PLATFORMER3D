using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float jumpForce;

    private float _velocity;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _storedVelocity;

    private bool _shouldJump;

    public void Jump()
    {
        _shouldJump = true;
        _velocity = jumpForce;
    }

    private void Update()
    {
        if (_shouldJump)
        {
            _velocity += Physics.gravity.y * Time.deltaTime * gravityMultiplier;
            Vector3 moveVector = Vector3.zero;
            moveVector.y = _velocity;
            characterController.Move(moveVector * Time.deltaTime);

            if (characterController.isGrounded)
            {
                _velocity = 0.0f;
                _shouldJump = false;
            }
        }
        else
        {
            if (!characterController.isGrounded)
            {
                _velocity = _storedVelocity;
            }

            _storedVelocity = _velocity + Physics.gravity.y * Time.deltaTime * gravityMultiplier;
            Vector3 moveVector = Vector3.zero;
            moveVector.y = _velocity;
            characterController.Move(moveVector * Time.deltaTime);
        }
    }
}

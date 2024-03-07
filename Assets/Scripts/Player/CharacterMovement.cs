using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] float rotationSpeed = 1f;

    private Vector3 _direction;

    private void Reset()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {

        Vector3 movementDirection = new Vector3(_direction.x, 0f, _direction.y);
        if (movementDirection.sqrMagnitude > Mathf.Epsilon)
        {
            movementDirection.Normalize();
        }

        if (movementDirection.sqrMagnitude == 0) return;


        float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        characterController.Move(movementDirection * movementSpeed * Time.deltaTime);
        //characterController.Move(new Vector3(_direction.x, 0, _direction.y) * speed * Time.deltaTime);

    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
}

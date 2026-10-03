using UnityEngine;
using UnityEngine.InputSystem; 

public class Escape : MonoBehaviour
{
    public float speed = 15f;
    InputAction moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 direction = new(input.x, 0, input.y);

        if (direction.sqrMagnitude < 0.000001f) return;
        transform.forward = direction.normalized;
        transform.position += speed * Time.deltaTime * direction;
    }
}

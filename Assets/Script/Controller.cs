using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private Transform cameraTransform; // Gán camera trong Inspector

    private Vector3 direction = Vector3.zero;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Tính hướng camera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Loại bỏ hướng lên/xuống
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Tính hướng di chuyển theo camera
        Vector3 moveDirection = forward * direction.z + right * direction.x;

        // Di chuyển nhân vật
        Vector3 movement = moveDirection * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    public void OnMove(InputValue value)
    {
        moveInput(value.Get<Vector2>());
    }

    private void moveInput(Vector2 vector2)
    {
        // Lưu input từ bàn phím
        direction = new Vector3(vector2.x, 0, vector2.y);
    }
}

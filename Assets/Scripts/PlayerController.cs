using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : PlayerProperties
{
    [Header("References")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private InputActionAsset playerMovement;

    [Header("Variables")]
    private Vector2 _moveDirection; // Karakterimizin hareket edeceği yön.

    private void Start()
    {
        playerMovement.Enable();    // Inputları aktif ettik.
    }

    private void Update()
    {
        _moveDirection = playerMovement.FindActionMap("Movement").FindAction("Move").ReadValue<Vector2>();  // Input değerini _moveDirection'a ata.
    }

    private void FixedUpdate()
    {
        Run();
        Flip();
    }

    private void Run()
    {
        _rb.linearVelocity = _moveDirection * _speed;       // Karakterin hareket kodu.

        if (_moveDirection.x != 0f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void Flip()
    {
        if (_moveDirection.x < 0)
        {
            transform.localScale = new Vector2(-1, 0);
        }
        else
        {
            transform.localScale = new Vector2(1, 0);
        }
        
    }
}

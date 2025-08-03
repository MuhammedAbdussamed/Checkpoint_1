using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public float _health;
    public float _mana;

    public float _speed;
    public float _jumpPower;

    [Header("Components")]
    public Animator animator;

    [Header("Bools")]
    public bool isGrounded;

    void Awake()
    {
        // Components
        animator = GetComponent<Animator>();
    }
}

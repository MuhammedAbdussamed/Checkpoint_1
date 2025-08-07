using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputActionAsset _playerMovement;
    [SerializeField] private PlayerProperties _playerData;

    [Header("Variables")]
    private Vector2 _moveDirection; // Karakterimizin hareket edeceği yön.
    private Vector2 _jumpDirection;

    private void Start()
    {
        _playerMovement.Enable();    // Inputları aktif ettik.
        _playerData._isFacingRight = true;    // Oyun başladığında karakter sağa dönük olduğu için true dedik
    }

    private void Update()
    {
        /* Functions */
        Flip();
        JumpStateTrigger();
        Attack();
        Dash();

        /* Inputs */
        _moveDirection = _playerMovement.FindActionMap("Movement").FindAction("Move").ReadValue<Vector2>();  // Input değerini _moveDirection'a ata.

        /* PlayerData Assign */
        _playerData._playerMoveDirection = _moveDirection;    // Bütün datayı tutan PlayerProperties'e moveDirection'u geçiriyoruz.
        _playerData._isWalking = _moveDirection.x != 0;     // isWalking değişkenini hız 0 dan farklıysa true yap.
        _playerData._jumpDirection = _jumpDirection;        // PlayerProperties'de ki jumpDirection değerini PlayerControllerda ki jumpDirection değeriyle aynı yaptık.
    }

    void OnEnable()
    {
        _playerMovement.FindActionMap("Jump").FindAction("Jumping").performed += ctx => _playerData._jumpPressed = true;    // Gelen Input ile _jumpPressed değişkenini true çevir.Bu bir event aboneliğidir.
    }

    void OnDisable()
    {
        _playerMovement.FindActionMap("Jump").FindAction("Jumping").performed -= ctx => _playerData._jumpPressed = true;    // Script devre dışı kalırsa aboneliği kaldır.
    }

    #region Functions

    private void Flip()
    {
        if (_moveDirection.x < 0f && _playerData._isFacingRight)  // Sola doğru gidiyor ve karakter sağa dönükse devam et.
        {
            Vector2 _scale = transform.localScale;                      //
            _scale.x *= -1;                                             // Karakterin scale değerini -1 ile çarpıp döndürüyoruz.
            transform.localScale = _scale;                              //

            _playerData._isFacingRight = false;
        }
        else if (_moveDirection.x > 0 && !_playerData._isFacingRight)
        {
            Vector2 _scale = transform.localScale;                      //
            _scale.x *= -1;                                             //  Karakterin scale değerini -1 ile çarpıp döndürüyoruz
            transform.localScale = _scale;                              // 

            _playerData._isFacingRight = true;
        }
    }

    private void JumpStateTrigger()
    {
        if (_playerData._isGrounded && _playerData._jumpPressed)    // Karakter yerde ise ve zıplama tuşuna basılmışsa.
        {
            _playerData._isJumping = true;                          // Karakter zıplıyor değişkenini true yap.
            _playerData._jumpPressed = false;                       // Tuşa basıldı mı değişkenini false yap ki döngü tekrar tekrar oynamasın.
        }
    }

    private void Attack()
    {
        if (_playerMovement.FindActionMap("Attack").FindAction("Attack1").triggered)    //  Bu input trigger olduğunda devam et.
        {
            _playerData._animator.SetTrigger("Attack1");             // Attack1 animasyonunu triggerla . ( Bir kere çalışmasına sebep olur )
        }

        if (_playerMovement.FindActionMap("Attack").FindAction("Attack2").triggered)    //  Bu input trigger olduğunda devam et.
        {
            _playerData._animator.SetTrigger("Attack2");            // Attack2 animasyonunu triggerla . ( Bir kere çalışmasına sebep olur )
        }
    }

    private void Dash()
    {
        if (_playerMovement.FindActionMap("Movement").FindAction("Dash").triggered)
        {
        }
    }

    #endregion

}

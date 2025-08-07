using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections;

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
        _playerData._mono = this;    // Monobehaviour referansın bu script yap.
    }

    private void Update()
    {
        /* Functions */
        Flip();
        JumpStateTrigger();
        Attack();
        DashStateTrigger();

        /* Inputs */
        _moveDirection = _playerMovement.FindActionMap("Movement").FindAction("Move").ReadValue<Vector2>();  // Input değerini _moveDirection'a ata.

        /* PlayerData Assign */
        _playerData._playerMoveDirection = _moveDirection;      // Bütün datayı tutan PlayerProperties'e moveDirection'u geçiriyoruz.
        _playerData._isWalking = _moveDirection.x != 0;         // isWalking değişkenini hız 0 dan farklıysa true yap.
        _playerData._jumpDirection = _jumpDirection;            // PlayerProperties'de ki jumpDirection değerini PlayerControllerda ki jumpDirection değeriyle aynı yaptık.
        gameObject.layer = _playerData._playerLayer;            // Player Properties'de ki layer değerini objeye yansıt.
    }

    void OnEnable()
    {
        _playerMovement.FindActionMap("Jump").FindAction("Jumping").performed += ctx => _playerData._jumpPressed = true;    // Gelen Input ile _jumpPressed değişkenini true çevir.Bu bir event aboneliğidir.
        _playerMovement.FindActionMap("Movement").FindAction("Dash").performed += ctx => _playerData._dashPressed = true;   // Gelen Input ile _dashPressed değişkenini true çevir.Bu bir event aboneliğidir.
    }

    void OnDisable()
    {
        _playerMovement.FindActionMap("Jump").FindAction("Jumping").performed -= ctx => _playerData._jumpPressed = true;    // Script devre dışı kalırsa aboneliği kaldır.
        _playerMovement.FindActionMap("Movement").FindAction("Dash").performed -= ctx => _playerData._dashPressed = false;  // Script devre dışı kalırsa aboneliği kaldır  
    }


    #region StateTransition

    private void JumpStateTrigger()
    {
        if (_playerData._isGrounded && _playerData._jumpPressed)    // Karakter yerde ise ve zıplama tuşuna basılmışsa.
        {
            _playerData._isJumping = true;                          // Karakter zıplıyor değişkenini true yap.
            _playerData._jumpPressed = false;                       // Tuşa basıldı mı değişkenini false yap ki döngü tekrar tekrar oynamasın.
        }
    }

    private void DashStateTrigger()
    {
        if (_playerData._dashPressed)                               // Dash her durumda atılabileceği için eğer dash tuşuna basılmışsa...
        {
            _playerData._isDashing = true;                          // Karakter atılıyor mu true çevir.
            _playerData._dashPressed = false;                       // Atılma tuşuna basıldı mı false çevir ki döngü tekrarlanmasın.
        }
    }

    #endregion

    #region Functions

    public void Run(PlayerProperties _playerData)
    {
        Vector2 newVelocity = new Vector2(_playerData._playerMoveDirection.x * _playerData._speed, _playerData._rb.linearVelocity.y);
        _playerData._rb.linearVelocity = newVelocity;
        if (_playerData._playerMoveDirection.x != 0f)
        {
            _playerData._animator.SetBool("isWalking", true);
            _playerData._isWalking = true;
        }
        else
        {
            _playerData._animator.SetBool("isWalking", false);
            _playerData._isWalking = false;
        }
    }

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

    private void Attack()
    {
        if (_playerMovement.FindActionMap("Attack").FindAction("Attack1").triggered)    //  Bu input trigger olduğunda devam et.
        {
            _playerData._animator.SetTrigger("Attack1");             // Attack1 animasyonunu triggerla . ( Bir kere çalışmasına sebep olur )
            Vector2 dashDirection = _playerData._isFacingRight ? Vector2.right : Vector2.left;
            _playerData._rb.linearVelocity = dashDirection * _playerData._dashSpeed;
            StartCoroutine(ResetAttack2(_playerData));
        }

        if (_playerMovement.FindActionMap("Attack").FindAction("Attack2").triggered)    //  Bu input trigger olduğunda devam et.
        {
            _playerData._animator.SetTrigger("Attack2");            // Attack2 animasyonunu triggerla . ( Bir kere çalışmasına sebep olur         
        }
    }

    IEnumerator ResetAttack2(PlayerProperties _playerData)
    {
        yield return new WaitForSeconds(_playerData._dashTime);
        _playerData._rb.linearVelocity = Vector2.zero;
    }

    #endregion

}

using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public static PlayerProperties Instance { get; private set; }  // get { return_ınstance; } // Dışarıdan bu koda erişim sağlar.

    public float _health;           // Karakterin canı.
    public float _mana;             // Karakterin manası.

    public float _speed;            // Karakterin hızı.
    public float _jumpPower;        // Karakterin zıplama gücü.

    public IState currentState;     // Şimdi ki durum.

    [Header("Components")]
    public Animator _animator;
    public Rigidbody2D _rb;

    [Header("Bools")]
    public bool _isGrounded;
    public bool _isWalking;
    public bool _isFacingRight;     // Karakterin dönmüş olduğu yönü temsil eder.
    
    public bool _isJumping;
    public bool _jumpPressed;

    public bool _isDashing;
    public bool _dashPressed;

    [Header("States")]
    public IState _idleState;       // Idle durumu
    public IState _walkState;       // Yürüme durumu
    public IState _jumpState;       // Zıplama durumu

    [Header("Variables")]
    public Vector2 _playerMoveDirection;
    public Vector2 _jumpDirection;

    void Awake()
    {
        if (Instance == null)                   // Eğer Instance null ise
        {
            Instance = this;                    // Instance'ı burada ata!
            DontDestroyOnLoad(gameObject);      // Sahne geçişlerinde yok olmasını engeller
        }
        else
        {
            Destroy(gameObject);                // Çift instance oluşmasını engelle
        }

        currentState = new Idle_State();        // İlk durumu idle olarak ayarla.
        _idleState = new Idle_State();          // Idle durumunun atamasını yaptık.
        _walkState = new Walk_State();          // Walk durumunun atamasını yaptık.
        _jumpState = new JumpState();           // Jump durumunun atamasını yaptık.
    }

    void Update()
    {
        currentState.Update(this);              // Güncel durumun update işlemi ne ise onu yap.
    }

    public void ChangeState(IState newState)
    {
        currentState.Exit(this);                // Şuan ki durumun çıkış işlemini gerçekleştir.
        currentState = newState;                // Durumu güncelle.
        currentState.Enter(this);               // Güncellenen durumun giriş işlemini gerçekleştir.
    }
    
    
}

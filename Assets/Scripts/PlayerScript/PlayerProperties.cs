using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public static PlayerProperties Instance { get; private set; }  // get { return_ınstance; } // Dışarıdan bu koda erişim sağlar.

    public float _health;           // Karakterin canı.
    public float _mana;             // Karakterin manası.

    public float _speed;            // Karakterin hızı.
    public float _jumpPower;        // Karakterin zıplama gücü.

    public MonoBehaviour _mono;     // State scriptlerinde Monobehaviour'un özelliklerini kullanabilmek için referans.
    public PlayerController _playerController;  // PlayerController referansı . Bu sayede diğer scriptlerden playerControllera ulaşabiliriz.

    public IState currentState;     // Şimdi ki durum.

    [Header("Components")]
    public Animator _animator;
    public Rigidbody2D _rb;
    public Transform _transform;
    public int _playerLayer;

    [Header("Bools")]
    public bool _isGrounded;        // Karakter yerde mi ?
    public bool _isWalking;         // Karakter yürüyor mu ?
    public bool _isFacingRight;     // Karakterin dönmüş olduğu yönü temsil eder.
    
    public bool _isJumping;         // Karakter zıplıyor mu?
    public bool _jumpPressed;       // Zıplama tuşuna basıldı mı?

    public bool _isDashing;         // Karakter atılıyor mu?
    public bool _dashPressed;       // Atılma tuşuna basıldı mı?
    public float _dashTime;         // Atılma süresi.
    public int _dashSpeed;          // Atılma hızı.
    
    [Header("States")]
    public IState _idleState;       // Idle durumu
    public IState _walkState;       // Yürüme durumu
    public IState _jumpState;       // Zıplama durumu
    public IState _dashState;       // Atılma durumu

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
        _dashState = new Dash_State();          // Atılma durumunun atamasını yaptık.
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

using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable_Object : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public AudioSource _environmentSound; // Ses kaynağı
    private PlayerProperties _playerData;                   // Karakter scripti.
    

    [Header("Variables")]
    private Transform _interactText;                     // Her Objede bulunan "Press E for interact" yazısını atayacağımız değişken.
    private bool _isPlayerInside;                        // Karakter objenin içerisinde mi?

    void Start()
    {
        _interactText = transform.Find("Interactable_Objects_Text");    // Objenin altında bulunan "Press"E" for interact" texti.
        _playerData = PlayerProperties.Instance;                        // PlayerProperties'i birden fazla kez kullanıcaz o yüzden değişkene atıyoruz.
    }

    private void Update()
    {
        if (_isPlayerInside && _playerData._interactionChecker)         // Karakter objenin içerisinde ve etkileşim tuşuna basılmış ise...
        {
            EnterCinematicFunction();                                   // Giriş fonksiyonunu çalıştır. (objeye özel olur)
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        TriggerFunction(col, true, false);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        TriggerFunction(col, false, true);
    }

    #region Functions

    private void TriggerFunction(Collider2D col , bool inOrOut ,bool isExit)
    {
        if (col.CompareTag("Player"))
        {
            _isPlayerInside = inOrOut;                                  // Karakter objenin yanında mı değil mi?
            ShowHideText(inOrOut);                                      // Etkileşim metni gözükecek mi gizlenecek mi?

            if (isExit)                                                 // isExit true verildiği takdirde çıkış fonksiyonu çalışacak.
            {
                ExitCinematicFunction();
            }
        }
    }

    public void ShowHideText(bool entering)
    {
        _interactText.gameObject.SetActive(entering);                  // Etkileşim metnini gizle ya da göster.( Parametreye göre )
    }

    protected virtual void EnterCinematicFunction() { }  // Üst scriptler tarafından kontrol edilebilen bir fonksiyon. 
    protected virtual void ExitCinematicFunction() { }  // Üst scriptler tarafından kontrol edilebilen bir fonksiyon.
    
    #endregion
}

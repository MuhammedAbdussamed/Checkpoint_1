using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable_Object : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public Animator _animator;                            // AnimationManager'da ki animator.
    [SerializeField] public InputActionReference _interactionInput;        // Etkileşim (E) tuşuna basılıp basılmadığını kontrol eden input action.

    [Header("Variables")]
    public Transform _interactText;                                        // Her Objede bulunan "Press E for interact" yazısı.

    public void Awake()
    {
        _interactText = transform.Find("Interactable_Objects_Text");
    }

    public void ShowHideText(bool entering)
    {
        _interactText.gameObject.SetActive(entering);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _interactText.gameObject.SetActive(true);
            if (_interactionInput.action.triggered)
            {
                ObjectFunction();
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _interactText.gameObject.SetActive(false);
        }
    }

    protected virtual void ObjectFunction(){}  // Üst scriptler tarafından kontrol edilebilen bir fonksiyon. 
}

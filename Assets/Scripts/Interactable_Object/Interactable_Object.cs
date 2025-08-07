using UnityEngine;

public class Interactable_Object : MonoBehaviour
{
    private Transform _interactText;

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
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _interactText.gameObject.SetActive(false);
        }
    }
}

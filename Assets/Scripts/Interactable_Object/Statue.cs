using UnityEngine;

public class Statue : Interactable_Object
{
    private Transform _statueText;

    void Awake()
    {
        _statueText = transform.Find("StatueText");         // Heykele özel metin. Sahnede child obje olarak geçer ve başlangıçta setactive'i false'dur.
    }

    protected override void EnterCinematicFunction()
    {
        _statueText.gameObject.SetActive(true);             // Özel metini etkinleştir.
        ShowHideText(false);                                // Etkileşim metnini kapat.
    }

    protected override void ExitCinematicFunction()
    {
        _statueText.gameObject.SetActive(false);            // Özel metini gizle.
    }
    
}

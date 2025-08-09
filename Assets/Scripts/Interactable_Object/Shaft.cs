using UnityEngine;

public class Shaft : Interactable_Object
{
    private Transform _shaftSpecialText;

    protected virtual void Awake()
    {
        _shaftSpecialText = transform.Find("ShaftSpecialText");     // Kuyuya özel metin. Scene'de child object olarak geçer ve başlangıçta setactive'i false'dur.
    }

    protected override void EnterCinematicFunction()
    {
        _shaftSpecialText.gameObject.SetActive(true);               // Özel metini etkinleştir.
        ShowHideText(false);                                        // Etkileşim metnini gizle.
    }

    protected override void ExitCinematicFunction()
    {
        _shaftSpecialText.gameObject.SetActive(false);              // Özel metni gizle.
    }
}

using UnityEngine;

public class Checkpoint : Interactable_Object
{
    [SerializeField] AudioClip _fireIgnition;               // Ateş yakma sesi
    private Transform _fire;                                // Objede ki ateş efekti.
    public bool _isFiring;

    protected override void EnterCinematicFunction()
    {
        _fire = transform.Find("Fire");                     // Child object olan ateşi al
        _fire.gameObject.SetActive(true);                   // Ve onu etkinleştir.
        _environmentSound.PlayOneShot(_fireIgnition);       // Ateş yakma sesini bir kere çal.
        _isFiring = true;
    }
}

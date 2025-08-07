using UnityEngine;

public class Effect_Script : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource _playerSounds; // Ses çalmak için çağırdığımız kaynak.

    [Header("Sounds")]
    [SerializeField] private AudioClip _heavyAttackSound;    // Ses
    [SerializeField] private AudioClip _lightAttackSound;   // Ses

    public void PlayHeavyAttack()
    {
        _playerSounds.PlayOneShot(_heavyAttackSound);        // AudioSource'da ki _heavyAttackSound ses dosyasını BİR KERE çal.
    }

    public void PlayLightAttack()
    {
        _playerSounds.PlayOneShot(_lightAttackSound);       // AudioSource'da ki _lightAttackSound ses dosyasını BİR KERE çal.
        Debug.Log("Tetiklendi");
    }
}

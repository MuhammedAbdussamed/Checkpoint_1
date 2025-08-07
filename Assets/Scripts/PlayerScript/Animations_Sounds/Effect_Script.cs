using UnityEngine;

public class Effect_Script : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource _playerSounds; // Ses çalmak için çağırdığımız kaynak.

    [Header("Sounds")]
    [SerializeField] private AudioClip _heavyAttackSound;    // Ses
    [SerializeField] private AudioClip _lightAttackSound;    // Ses
    [SerializeField] private AudioClip _dashSound;           // Ses

    public void HeavyAttack()
    {
        _playerSounds.PlayOneShot(_heavyAttackSound);        // AudioSource'da ki _heavyAttackSound ses dosyasını BİR KERE çal.
    }

    public void LightAttack()
    {
        _playerSounds.PlayOneShot(_lightAttackSound);       // AudioSource'da ki _lightAttackSound ses dosyasını BİR KERE çal.
    }

    public void Dash()
    {
        _playerSounds.PlayOneShot(_dashSound);              // AudioSource'da ki _dashSound ses dosyasını BİR KERE çal.
    }
}

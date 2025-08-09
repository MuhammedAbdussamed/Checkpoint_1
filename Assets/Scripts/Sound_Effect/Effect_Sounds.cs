using UnityEngine;

public class Effect_Sounds : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] private Checkpoint _checkpointFire;

    [Header("Component References")]
    [SerializeField] private AudioSource _environmentAudio;

    [Header("Sound Files")]
    [SerializeField] private AudioClip _fireSound;

    void Update()
    {
        if (_checkpointFire._isFiring)
        {
            _environmentAudio.loop = true;
            _environmentAudio.clip = _fireSound;
            _environmentAudio.Play();
        }

    }

}

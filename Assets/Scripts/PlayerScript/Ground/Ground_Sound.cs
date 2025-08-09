using UnityEngine;

public class Ground_Sound : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioSource _environmentAudio;
    [SerializeField] private Ground_Material _groundMaterial;
    private PlayerProperties _playerData;

    [Header("Sound Files")]
    [SerializeField] private AudioClip _grassGroundAudio;
    [SerializeField] private AudioClip _stoneGroundAudio;

    void Awake()
    {
        _environmentAudio.loop = true;
    }

    void Start()
    {
        _playerData = PlayerProperties.Instance;
    }

    void Update()
    {
        if (_playerData._isWalking)
        {
            if (_groundMaterial._isOnGrass)
            {
                ChangeGroundAudio(_grassGroundAudio);
            }
            else if (_groundMaterial._isOnStone)
            {
                ChangeGroundAudio(_stoneGroundAudio);
            }
        }
        else
        {
            _environmentAudio.Stop();
        }
    }

    void ChangeGroundAudio(AudioClip clip)
    {
        if (_environmentAudio.clip != clip)
        {
            _environmentAudio.clip = clip;
            _environmentAudio.Play();
        }
        else if (!_environmentAudio.isPlaying)
        {
            _environmentAudio.Play();
        }
    }
}

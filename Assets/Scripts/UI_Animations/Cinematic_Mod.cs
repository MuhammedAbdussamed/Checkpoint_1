using UnityEngine;
using DG.Tweening;
using Unity.Cinemachine;      // DOTween animasyonlarını kullanabilmemiz için gerekli olan kütüphane.

/*
public class Cinematic_Mod : MonoBehaviour
{
    [Header("References")]
    public PlayerProperties _playerData;
    public CinemachineCamera _playerCamera;

    [Header("Variables")]
    public RectTransform _topBar;          // Üstte ki bar.
    public RectTransform _bottomBar;       // Altta ki bar.

    public float _animationTime;           // Kayma süresi
    public float _targetHeight;            // Şeritlerin ekranda olacağı son konumun yüksekliği. 

    private Tween _fovTween;               // Animasyonu takip edeceğimiz değişken

    public float _targetCameraFov;         // Hedef kamera FOV'u.
    public float _changeFovTime;           // Kamera FOV'unu değiştireceğimiz süre. (2sn içinde gibi)

    void Start()
    {
        _playerData = PlayerProperties.Instance;
        DOTween.SetTweensCapacity(500, 50);
    }

    void Update()
    {
        if (_isPlayerInside)
        {
            ShowBar();
            ChangeFov(_targetCameraFov, _changeFovTime);
        }
        else
        {
            HideBar();
        }
    }

    void ShowBar()                         // Sinematik siyah barları ekrana getir.
    {
        _topBar.DOAnchorPosY(_targetHeight, _animationTime).SetEase(Ease.OutQuad);  // DOAnchorPosY rectTransformlari animasyon ile değiştirir. (Şuan için y ekseninde)
        _bottomBar.DOAnchorPosY(-_targetHeight, _animationTime).SetEase(Ease.OutQuad);  // SetEase animasyonun hız eğrisini belirler. OutQuad başta hızlı başlatır sonra yavaşlar.
    }

    void HideBar()                         // Sinematik siyah barları ekrandan kaldır. 
    {
        _topBar.DOAnchorPosY(_targetHeight + 200, _animationTime).SetEase(Ease.OutQuad);
        _bottomBar.DOAnchorPosY(_targetHeight - 200, _animationTime).SetEase(Ease.OutQuad);
    }

    void ChangeFov(float targetFov, float time)
    {
        if (_fovTween != null && _fovTween.IsActive()) { return; }      // Animasyon çalışıyor mu?

        _fovTween = DOVirtual.Float(                    // FovTween animasyonunu bu fonksiyona atadık ki kontrol edebilelim.
            _playerCamera.Lens.OrthographicSize,        // Mevcut değer.
            targetFov,                                  // Hedef değer.
            time,                                       // Süre
            value => _playerCamera.Lens.OrthographicSize = value    //Bana her yeni değeri ver. Sonra bu değeri fova ata. Böylece yumuşak geçiş sağla 
        ).SetEase(Ease.OutQuad);    // Yine hız değişkeni . Başta hızlı sonra yavaş.

    }
}
*/

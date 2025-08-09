using UnityEngine;

public class isGrounded : MonoBehaviour
{
    [Header("Raycast Collision Matrix")]
    [SerializeField] private LayerMask _layerMask;  // Raycastin çarpacağı layer'ları seçecek olan değişken.
    private RaycastHit2D hit;

    [Header("References")]
    [SerializeField] private Ground_Material _groundScript;
    private PlayerProperties _playerData;

    void Start()
    {
        _playerData = PlayerProperties.Instance;
    }

    void Update()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.down, 0.05f, _layerMask);  // Bu pozisyondan aşağı doğru 0.05f uzunluğunda bir raycast oluştur ve sadece layermask'in seçtiği katmanlara çarp.
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 0.05f, Color.red);   // Yukarı da ki ışını görselleştir.

        if (hit.collider != null)
        {
            _playerData._isGrounded = true;   // Karakter yerde mi true döndür.
        }
        else
        {
            _playerData._isGrounded = false;  // Karakter yerde mi false döndür.
        }

        ChangeGroundSound();
    }

    void ChangeGroundSound()
    {
        if (hit.collider == null)
        {
            _groundScript._isOnGrass = false;
            _groundScript._isOnStone = false;
        }

        else if (hit.collider.gameObject.layer == 22)
        {
            _groundScript._isOnGrass = true;
            _groundScript._isOnStone = false;
        }

        else if (hit.collider.gameObject.layer == 21)
        {
            _groundScript._isOnStone = true;
            _groundScript._isOnGrass = false;
        }
    }

}

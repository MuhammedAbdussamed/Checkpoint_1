using UnityEngine;

public class isGrounded : MonoBehaviour
{
    [Header("Raycast Collision Matrix")]
    [SerializeField] private LayerMask _layerMask;  // Raycastin çarpacağı layer'ları seçecek olan değişken.

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.05f, _layerMask);  // Bu pozisyondan aşağı doğru 0.05f uzunluğunda bir raycast oluştur ve sadece layermask'in seçtiği katmanlara çarp.
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 0.05f, Color.red);   // Yukarı da ki ışını görselleştir.

        if (hit.collider != null)
        {
            PlayerProperties.Instance._isGrounded = true;   // Karakter yerde mi true döndür.
        }
        else
        {
            PlayerProperties.Instance._isGrounded = false;  // Karakter yerde mi false döndür.
        }
    }

}

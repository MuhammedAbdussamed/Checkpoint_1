using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Ender : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   // Bu sahnenin buildIndex'ini al veona 1 ekle. Sonra çıkan sonuça sahip indexli sahneyi yükle.
        }
    }
}

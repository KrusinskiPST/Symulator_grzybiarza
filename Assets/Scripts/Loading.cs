using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Dodaj tê liniê

public class Loading : MonoBehaviour
{
    public Animator animator; // Przypisz swój Animator tutaj

    void Start()
    {
        StartCoroutine(WaitForAnimation());
    }

    IEnumerator WaitForAnimation()
    {
        // Czekaj na zakoñczenie animacji
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Wczytaj scenê "Game"
        SceneManager.LoadScene("Game");
    }
}

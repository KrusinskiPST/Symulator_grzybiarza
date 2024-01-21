using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Dodaj t� lini�

public class Loading : MonoBehaviour
{
    public Animator animator; // Przypisz sw�j Animator tutaj

    void Start()
    {
        StartCoroutine(WaitForAnimation());
    }

    IEnumerator WaitForAnimation()
    {
        // Czekaj na zako�czenie animacji
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Wczytaj scen� "Game"
        SceneManager.LoadScene("Game");
    }
}

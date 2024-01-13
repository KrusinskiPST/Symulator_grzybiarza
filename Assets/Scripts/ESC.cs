using UnityEngine;

public class ESC : MonoBehaviour
{
    public GameObject menuPanel; // Referencja do panelu menu UI

    void Start()
    {
        // Sprawd�, czy panel menu jest przypisany w inspektorze
        if (menuPanel == null)
        {
            Debug.LogError("Menu panel not assigned in the inspector!");
        }
        else
        {
            // Ukryj menu na starcie
            menuPanel.SetActive(false);
        }
    }

    void Update()
    {
        // Sprawd�, czy klawisz Esc zosta� naci�ni�ty
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Poka� lub ukryj menu w zale�no�ci od jego obecnej widoczno�ci
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        // Zmie� stan aktywacji menu
        bool isMenuActive = !menuPanel.activeSelf;
        menuPanel.SetActive(isMenuActive);

        // Zatrzymaj czas lub wznow czas w zale�no�ci od widoczno�ci menu
        Time.timeScale = isMenuActive ? 0f : 1f;

        // Zablokuj lub odblokuj kursor myszy
        Cursor.lockState = isMenuActive ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isMenuActive;
    }
}

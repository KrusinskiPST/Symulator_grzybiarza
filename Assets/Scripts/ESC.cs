using UnityEngine;

public class ESC : MonoBehaviour
{
    public GameObject menuPanel; // Referencja do panelu menu UI

    void Start()
    {
        // SprawdŸ, czy panel menu jest przypisany w inspektorze
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
        // SprawdŸ, czy klawisz Esc zosta³ naciœniêty
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Poka¿ lub ukryj menu w zale¿noœci od jego obecnej widocznoœci
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        // Zmieñ stan aktywacji menu
        bool isMenuActive = !menuPanel.activeSelf;
        menuPanel.SetActive(isMenuActive);

        // Zatrzymaj czas lub wznow czas w zale¿noœci od widocznoœci menu
        Time.timeScale = isMenuActive ? 0f : 1f;

        // Zablokuj lub odblokuj kursor myszy
        Cursor.lockState = isMenuActive ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isMenuActive;
    }
}

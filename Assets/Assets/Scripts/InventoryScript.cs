using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject inventoryUI; // Przypisz obiekt UI ekwipunku
    private bool isInventoryActive = false;

    public FP_Mov playerMovementScript; // Referencja do skryptu ruchu postaci

    void Start()
    {
        // Ukryj ekwipunek na pocz�tku
        inventoryUI.SetActive(false);
    }

    void Update()
    {
        // Sprawdzanie, czy klawisz Tab lub E zosta� naci�ni�ty
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isInventoryActive = !isInventoryActive; // Prze��cza stan ekwipunku
            inventoryUI.SetActive(isInventoryActive); // Aktywuje/deaktywuje UI ekwipunku

            // Obs�uga kursora myszy i ruchu postaci
            if (isInventoryActive)
            {
                Cursor.lockState = CursorLockMode.None; // Odblokowuje kursor
                Cursor.visible = true; // Pokazuje kursor
                playerMovementScript.canMove = false; // Wy��cza ruch postaci
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked; // Blokuje kursor
                Cursor.visible = false; // Ukrywa kursor
                playerMovementScript.canMove = true; // W��cza ruch postaci
            }
        }
    }
}

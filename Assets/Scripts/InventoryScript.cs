using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject inventoryUI; // Przypisz obiekt UI ekwipunku
    private bool isInventoryActive = false;

    void Update()
    {
        // Sprawdzanie, czy klawisz Tab lub E zosta� naci�ni�ty
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.E))
        {
            isInventoryActive = !isInventoryActive; // Prze��cza stan ekwipunku
            inventoryUI.SetActive(isInventoryActive); // Aktywuje/deaktywuje UI ekwipunku
        }
    }
}

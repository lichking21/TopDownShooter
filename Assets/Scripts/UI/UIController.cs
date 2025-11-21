using System;
using UnityEngine;
using UnityEngine.UI;

class UIController : MonoBehaviour
{
    private InventoryContoroller inventoryPanel;

    private bool isInventoryOpened;

    void Awake()
    {
        inventoryPanel = GameObject.Find("InventoryPanel").GetComponent<InventoryContoroller>();

        inventoryPanel.gameObject.SetActive(false);

        isInventoryOpened = false;
    }

    public void OpenBackPack()
    {
        isInventoryOpened = !isInventoryOpened;
        inventoryPanel.gameObject.SetActive(isInventoryOpened);
        inventoryPanel.OnOpenRefresh();
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
    }
}
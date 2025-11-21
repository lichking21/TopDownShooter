using System;
using UnityEngine;
using UnityEngine.UI;

class UIController : MonoBehaviour
{
    private GameObject inventoryPanel;

    private bool isInventoryOpened;

    void Awake()
    {
        inventoryPanel = GameObject.Find("InventoryPanel");

        inventoryPanel.SetActive(false);

        isInventoryOpened = false;
    }

    public void OpenBackPack()
    {
        isInventoryOpened = !isInventoryOpened;
        inventoryPanel.SetActive(isInventoryOpened);
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
    }
}
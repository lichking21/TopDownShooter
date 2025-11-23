using System;
using UnityEngine;
using UnityEngine.UI;

class UIController : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    [SerializeField] private GameObject shootBtn;
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
        shootBtn.SetActive(!isInventoryOpened);
        inventoryPanel.OnOpenRefresh();
    }

    public void OnShootDown() => player.StartShoot();
    public void OnShootUp() => player.StopShoot();
}
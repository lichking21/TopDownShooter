using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text count;

    [SerializeField] private GameObject deleteBtn;
    private bool isSlotMenuOpened;

    public ItemSlot currSlot;
    public event Action<SlotUI> OnSlotSelected;

    void Awake()
    {
        icon.enabled = false;

        deleteBtn.SetActive(false);
        isSlotMenuOpened = false;
    }

    public void SetData(ItemSlot item)
    {
        currSlot = item;

        icon.sprite = item.Item.Icon;
        icon.enabled = true;
        count.text = item.Count > 1 ? item.Count.ToString() : ""; 
    }
    public void Clear()
    {
        currSlot = null;
        icon.enabled = false;
        count.text = "";
    }

    public void OnSlotClick()
    {
        OnSlotSelected?.Invoke(this);

        isSlotMenuOpened = !isSlotMenuOpened;
        deleteBtn.SetActive(isSlotMenuOpened);
    } 
        
}
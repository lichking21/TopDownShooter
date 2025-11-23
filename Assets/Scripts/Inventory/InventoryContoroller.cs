using System.Collections.Generic;
using UnityEngine;

public class InventoryContoroller : MonoBehaviour
{
    [SerializeField] List<SlotUI> uiSlots;
    [SerializeField] Inventory inv;

    private ItemSlot selectedSlot;

    void Awake()
    {
        foreach(var s in uiSlots)
            s.OnSlotSelected += OnSlotClicked;

        if (inv != null)
        {
            inv.OnInventoryChanged += RefreshUI;
        }
    }

    void OnSlotClicked(SlotUI slotUI)
    {
        selectedSlot = slotUI.currSlot;
    }

    public void DeleteSelected()
    {
        if (selectedSlot == null) return;

        inv.RemoveItem(selectedSlot);
        RefreshUI();
    }

    public void OnOpenRefresh() => RefreshUI();

    void RefreshUI()
    {
        var slots = inv.slots;

        for (int i = 0; i < uiSlots.Count; i++)
        {
            if (i < slots.Count)
                uiSlots[i].SetData(slots[i]);
            else 
                uiSlots[i].Clear();
        }

        if (selectedSlot != null && !slots.Contains(selectedSlot))
        {
            selectedSlot = null;
        }
    }
}
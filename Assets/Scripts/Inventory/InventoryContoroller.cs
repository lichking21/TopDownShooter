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
    }

    void OnSlotClicked(SlotUI slotUI)
    {
        selectedSlot = slotUI.currSlot;
    }

    public void DeleteSelected()
    {
        if (selectedSlot == null) return;

        inv.RemoveItem(selectedSlot);
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
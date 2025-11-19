using System.Collections.Generic;
using UnityEngine;

public class InventoryContoroller : MonoBehaviour
{
    [SerializeField] List<SlotUI> uiSlots;
    [SerializeField] Inventory inv;

    void OnEnable()
    {
        inv.OnInventoryChanged += RefreshUI;
    }
    void OnDisable()
    {
        inv.OnInventoryChanged -= RefreshUI;
    }

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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemSlot> slots = new List<ItemSlot>();

    public event Action OnInventoryChanged;

    public void AddItem(ItemSO item, int count)
    {
        ItemSlot slot = slots.FirstOrDefault(s => s.Item == item);
        if (slot != null && item.MaxStack > 1)
        {
            slot.Count += count;
        }
        else
        {
            ItemSlot newSlot = new ItemSlot(item, count);
            slots.Add(newSlot);
            Debug.Log($"Item {newSlot.Item} was added to inventory.\nCount in invetory {newSlot.Count}");
        }

        OnInventoryChanged?.Invoke();
    }

    public void RemoveItem(ItemSlot slot)
    {
        if (slot == null) return;

        slot.Count--;
        Debug.Log($"Items left: {slot.Count}");

        if (slot.Count <= 0) 
            slots.Remove(slot);

        OnInventoryChanged?.Invoke();
    }
}
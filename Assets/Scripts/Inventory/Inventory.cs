using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event Action OnInventoryChanged;

    public List<ItemSlot> slots = new List<ItemSlot>();

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

    public void RemoveItem(ItemSO item)
    {
        ItemSlot slot = slots.FirstOrDefault(s => s.Item == item);
        if (slot != null)
        {
            if (slot.Count > 1)
                slot.Count -= 1;
            else if (slot.Count == 1)
            {
                slots.Remove(slot);
            }
        }
    }
}
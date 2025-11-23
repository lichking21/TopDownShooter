using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemSlot> slots = new List<ItemSlot>();

    public event Action OnInventoryChanged;
    public event Action<ItemSO> OnItemRemoved;

    public void AddItem(ItemSO item, int count)
    {
        Debug.Log($"ADDING ITEM: id={item?.ID} name={item?.name} icon={(item?.Icon!=null?item.Icon.name:"null")} count={count} into inventory: {this}");
        
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
        {
            slots.Remove(slot);
            OnItemRemoved?.Invoke(slot.Item);
        }

        OnInventoryChanged?.Invoke();
    }

    public ItemSlot GetSlot(ItemSO item)
    {
        return slots.FirstOrDefault(s => s.Item == item);
    }
}
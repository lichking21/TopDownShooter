using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/ItemDatabase")]
public class ItemDB : ScriptableObject
{
    public List<ItemSO> items;

    public ItemSO GetByID(int id)
    {
        return items.FirstOrDefault(item => item.ID == id);
    }
}
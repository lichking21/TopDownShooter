using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemSO : ScriptableObject
{
    public int ID;
    public string Name;
    public string Type;
    public Sprite Icon;
    public int MaxStack;
    
    public GameObject Prefab;
}
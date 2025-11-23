using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public float playerHp;
    public float playerPosX;
    public float playerPosY;
    public int equipedWeaponID;

    public List<InventorySlotData> inventorySlots;
    public List<EnemyData> enemies;
}

[System.Serializable]
public class InventorySlotData
{
    public int itemId;
    public int count;
}

[System.Serializable]
public class EnemyData
{
    public string id;
    public float hp;
    public float posX;
    public float posY;
}

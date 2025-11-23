using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlayerController playerController;
    [SerializeField] Inventory inv;
    [SerializeField] ItemDB itemDB;
    [SerializeField] EnemyManager enemyManager;

    public void SaveGame()
    {
        SaveData saveData = new SaveData();

        // save player data
        saveData.playerHp = player.currHp;
        saveData.playerPosX = player.transform.position.x;
        saveData.playerPosY = player.transform.position.y;
        saveData.equipedWeaponID = playerController.currWeapon != null ? playerController.currWeapon.itemSO.ID : -1;

        // save inventory data
        saveData.inventorySlots = new List<InventorySlotData>();
        if (inv != null && inv.slots != null)
        {
            foreach(var slot in inv.slots)
            {
                if (slot.Item == null || slot == null) continue;
                saveData.inventorySlots.Add(new InventorySlotData
                {
                    itemId = slot.Item.ID,
                    count = slot.Count 
                });
                Debug.Log($"Saving inventory slot: id={slot.Item.ID} name={slot.Item.name} count={slot.Count}");
            }
        }
        else 
            Debug.Log("Inventory or invetory slots is nll while saving");

        //save enemies data
        saveData.enemies = enemyManager.GetData();

        SaveSystem.Save(saveData);
        Debug.Log("Game saved");
    }

    public void LoadGame()
    {
        SaveData saveData = SaveSystem.Load();
        if (saveData == null)
        {
            Debug.Log("No save data found");
            return;
        }

        // load inventory data
        inv.slots.Clear();
        if (saveData.inventorySlots != null)
        {
            foreach(var slotData in saveData.inventorySlots)
            {
                ItemSO item = itemDB.GetByID(slotData.itemId);
                if (item == null)
                {
                    Debug.Log($"No {slotData.itemId} id database");
                    continue;
                }

                inv.AddItem(item, slotData.count);
            }
        }
        else 
            Debug.Log("Saved inventorySlots is null");

        // load player data
        player.currHp = saveData.playerHp;
        player.transform.position = new Vector2(saveData.playerPosX, saveData.playerPosY);
        if (saveData.equipedWeaponID != -1)
        {
            ItemSO item = itemDB.GetByID(saveData.equipedWeaponID);

            if (item != null)
            {
                Weapon equippedWeapon = item.Prefab.GetComponent<Weapon>().Equip(item, playerController, inv);
                playerController.currWeapon = equippedWeapon;
            }
            else 
                Debug.Log($"No weapon with ID {saveData.equipedWeaponID} in database");
        }

        // load enemies data
        if (saveData.enemies != null) 
            enemyManager.LoadData(saveData.enemies);
        else 
            Debug.Log("Saved enemies data is null");

        Debug.Log("Game Loaded");
    }

    void Awake()
    {
        inv.OnItemRemoved += playerController.OnItemRemove;
    }

    IEnumerator Start()
    {
        yield return null;
        LoadGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5)) SaveGame();
        if (Input.GetKeyDown(KeyCode.F9)) LoadGame();
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }
}

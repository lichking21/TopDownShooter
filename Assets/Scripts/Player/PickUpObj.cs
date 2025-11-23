using UnityEngine;

public class PickUpObj : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemSO item;
    [SerializeField] private int count;
    private PlayerController player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void PickUp()
    {
        inventory.AddItem(item, count);

        switch(item.Type)
        {
            case "Weapon_AR":
                var weapon = item.Prefab.GetComponent<Weapon>();
                player.currWeapon = weapon.Equip(item, player, inventory);
                break;
            case "Ammo":
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inventory = collision.GetComponent<Inventory>();
            PickUp();   
            Destroy(gameObject);
        }
    }
}
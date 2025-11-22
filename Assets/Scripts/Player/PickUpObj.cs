using UnityEngine;

public class PickUpObj : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemSO item;
    [SerializeField] private int count;
    private PlayerController player;
    private Vector3 weaponPos = new Vector3(0.05f, -0.02f, 0); 

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
                GameObject weaponAR = Instantiate(item.Prefab);
                weaponAR.transform.SetParent(player.holdPoint_AR.transform);
                weaponAR.transform.localPosition = weaponPos;
                
                var w = weaponAR.GetComponent<Weapon>();
                w.inv = inventory;
                player.currWeapon = w;
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
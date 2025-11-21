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

        if (item.Type == "Weapon_AR")
        {
            GameObject weaponAR = Instantiate(item.Prefab);
            weaponAR.transform.SetParent(player.holdPoint_AR.transform);
            weaponAR.transform.localPosition = weaponPos;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUp();   
            Destroy(gameObject);
        }
    }
}
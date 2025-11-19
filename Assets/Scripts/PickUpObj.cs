using UnityEngine;

public class PickUpObj : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemSO item;
    [SerializeField] private int count = 1;

    void PickUp()
    {
        inventory.AddItem(item, count);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            PickUp();    
        } 
    }
}
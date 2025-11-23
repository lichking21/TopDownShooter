using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int weaponDamage;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private ItemSO ammoType;

    private Vector3 weaponPos; 
    public Inventory inv;
    public ItemSO itemSO;

    public void Shoot(PlayerController player)
    {
        var ammo = inv.GetSlot(ammoType);

        if (ammo == null)
        {
            Debug.LogError("ammo is null");
            return;
        }

        var newBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Bullet b = newBullet.GetComponent<Bullet>();
        b.bulletDamage = weaponDamage;
        b.SetBulletDirection(player.faceRight);

        ammo.Count--;

        if (ammo.Count <= 0)
            inv.RemoveItem(ammo);
    }

    public Weapon Equip(ItemSO item, PlayerController player, Inventory inventory)
    {
        GameObject weaponObj = Instantiate(item.Prefab);

        weaponObj.transform.SetParent(player.holdPoint_AR.transform);

        switch(item.Type)
        {
            case "Weapon_AR":
                weaponPos = new Vector3(0.05f, -0.02f, 0);
                weaponObj.transform.localPosition = weaponPos;
                break;
        }

        Weapon weapon = weaponObj.GetComponent<Weapon>();

        itemSO = item;
        inv = inventory;

        player.currWeapon = weapon;

        return weapon;
    }
}
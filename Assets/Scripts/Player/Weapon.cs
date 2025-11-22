using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int weaponDamage;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    
    [SerializeField] private ItemSO ammoType;
    public Inventory inv;

    public void Shoot()
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

        ammo.Count--;

        if (ammo.Count <= 0)
            inv.RemoveItem(ammo);
    }
}
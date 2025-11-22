using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    public int bulletDamage;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            var enemy = collider.GetComponent<Enemy>();
            enemy.TakeDamage(bulletDamage);
        }
    }
}
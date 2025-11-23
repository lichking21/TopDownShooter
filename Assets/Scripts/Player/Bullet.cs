using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    public int bulletDamage;
    private Vector2 dir;

    public void SetBulletDirection(bool faceRight)
    {
        dir = faceRight ? Vector2.right : Vector2.left;
    }

    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
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
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private HealthBar hpBar;
    public float currHp;

    public string ID;

    void Start()
    {
        currHp = maxHp;
        hpBar.UpdateHpBar(maxHp, currHp);
    }

    public void LoadState(float hp)
    {
        currHp = hp;
        hpBar.UpdateHpBar(maxHp, currHp);
    }

    public void TakeDamage(int damage)
    {
        currHp -= damage;
        hpBar.UpdateHpBar(maxHp, currHp);

        if (currHp <= 0)
        {
            Debug.Log("DEAD");
            Destroy(gameObject);
        }
    }
}
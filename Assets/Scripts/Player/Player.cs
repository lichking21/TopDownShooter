using UnityEngine;

class Player : MonoBehaviour
{
    [SerializeField] private HealthBar hpBar;
    [SerializeField] private float hp;
    public float currHp;

    void Start()
    {
        currHp = hp;
        hpBar.UpdateHpBar(hp, currHp);
    }

    public void TakeDamage(int damage)
    {
        currHp -= damage;
        hpBar.UpdateHpBar(hp, currHp);

        if (currHp <= 0)
        {
            
        }
    }
}
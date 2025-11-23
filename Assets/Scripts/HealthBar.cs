using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image hpBar;

    public void UpdateHpBar(float maxHp, float currHp)
    {
        hpBar.fillAmount = currHp / maxHp;
    }
}

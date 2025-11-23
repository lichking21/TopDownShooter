using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();

    public List<EnemyData> GetData()
    {
        List<EnemyData> datas = new List<EnemyData>();

        foreach(var e in enemies)
        {
            if (e == null) continue;

            datas.Add(new EnemyData()
            {
               id = e.ID,
               hp = e.currHp,
               posX = e.transform.position.x,
               posY = e.transform.position.y 
            });
        }

        return datas;
    }

    public void LoadData(List<EnemyData> savedDatas)
    {
        foreach (var saved in savedDatas)
        {
            foreach (var enemy in enemies)
            {
                if (enemy.ID == saved.id)
                {
                    enemy.transform.position = new Vector3(saved.posX, saved.posY, 0);
                    enemy.LoadState(saved.hp);
                }
            }
        }
    }
}
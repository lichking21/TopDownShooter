using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float minX, minY;
    [SerializeField] private float maxX, maxY;
    
    public List<Enemy> enemies = new List<Enemy>();
    private List<Enemy> spawnedEnemies = new List<Enemy>();

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

    void SpawnEnemy()
    {
        if (enemies == null)
        {
            Debug.Log("There is no enemies to spawn");
            return;
        } 

        for(int i = 0; i < 3; i++)
        {
            foreach(var enemy in enemies)
            {
                float x = Random.Range(minX, maxX);
                float y = Random.Range(minY, maxY);
                
                Vector2 spawnPoint = new Vector2(x, y);
                Enemy newEnemy = Instantiate(enemy, spawnPoint, Quaternion.identity);
                spawnedEnemies.Add(newEnemy);
            }
        }
    }

    void Start()
    {
        SpawnEnemy();    
    }
}
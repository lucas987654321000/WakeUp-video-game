using System.Collections.Generic;
using UnityEngine;

public class EnemyAwarenessZone : MonoBehaviour
{
    public List<Enemy> enemies;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.state = Enemy.State.Chase;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.state = Enemy.State.Patrol;
            }
        }
    }

}

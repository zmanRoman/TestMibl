using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawners
{
    public class EnemySpawner : Spawner
    {
        [SerializeField] private Enemy enemyPrefab;
        private List<Enemy> enemies = new ();
        private float speed;
        private float cdStartSpawnEnemy;
        private float intervalSpawnEnemy;
        private float countSpawnEnemy;
        private Transform enemyTarget;
        private Coroutine spawnCoroutine;
        
        public override void Init(Config.Config config, Transform enemyTarget = null)
        {
            speed = config.SpeedEnemy;
            cdStartSpawnEnemy = config.CdStartSpawnEnemy;
            intervalSpawnEnemy = config.IntervalSpawnEnemy;
            countSpawnEnemy = config.CountSpawnEnemy;
            if(enemyTarget)
                this.enemyTarget = enemyTarget;
        }
        
        public override void Spawn()
        {
            spawnCoroutine = StartCoroutine(SpawnPrefabsOnMesh());
        }
    
        private IEnumerator SpawnPrefabsOnMesh()
        {
            Mesh mesh = targetMeshFilter.mesh;
            
            yield return new WaitForSeconds(cdStartSpawnEnemy);
            
            while (true)
            {
                for (int i = 0; i < countSpawnEnemy; i++)
                {
                    Vector3 randomPointOnMesh = GetRandomPointOnMesh(mesh);
                    var enemy = Instantiate(enemyPrefab, randomPointOnMesh, Quaternion.identity);
                    enemy.Init(speed);
                    enemy.InitTarget(enemyTarget);
                    enemies.Add(enemy);
                }
                yield return new WaitForSeconds(intervalSpawnEnemy);
            }
        }
        
        public override void StopSpawn()
        {
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
            }

            Delete();
        }

        private void Delete()
        {
            foreach (var enemy in enemies)
            {
                Destroy(enemy.gameObject);
            }
            enemies.Clear();
        }
    }
}

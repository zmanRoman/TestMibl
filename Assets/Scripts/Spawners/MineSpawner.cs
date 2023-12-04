using System.Collections.Generic;
using UnityEngine;

namespace Spawners
{
    public class MineSpawner : Spawner
    {
        [SerializeField] private Mine minePrefab;
        private List<Mine> mines = new ();
        private float countMine;
        
        public override void Init(Config.Config config, Transform enemyTarget = null)
        {
            countMine = config.CountMine;
        }
    
        public override void Spawn()
        {
            Mesh mesh = targetMeshFilter.mesh;
            for (int i = 0; i < countMine; i++)
            {
                Vector3 randomPointOnMesh = GetRandomPointOnMesh(mesh);
                var mine = Instantiate(minePrefab, randomPointOnMesh, Quaternion.identity);
                mines.Add(mine);
            }
        }

        public override void StopSpawn()
        {
            Delete();
        }
        
        private void Delete()
        {
            foreach (var mine in mines)
            {
                Destroy(mine.gameObject);
            }
            mines.Clear();
        }
    }
}

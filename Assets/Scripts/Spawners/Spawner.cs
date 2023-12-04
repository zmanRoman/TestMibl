using UnityEngine;

namespace Spawners
{
    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] protected MeshFilter targetMeshFilter;
        public abstract void Init(Config.Config config, Transform enemyTarget = null);
        public abstract void Spawn();
        public abstract void StopSpawn();
        
        protected Vector3 GetRandomPointOnMesh(Mesh mesh)
        {
            int randomVertexIndex = Random.Range(1, mesh.vertices.Length - 1 );
            Vector3 randomVertex = mesh.vertices[randomVertexIndex];
            Vector3 randomPointOnMesh = targetMeshFilter.transform.TransformPoint(randomVertex);
            randomPointOnMesh.y += 0.5f;
            
            return randomPointOnMesh;
        }
    }
}

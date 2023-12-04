using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "Config", menuName = "Config", order = 1)]
    public class Config : ScriptableObject
    {
        [Header("Player")] 
        [SerializeField]private float _speedPlayer;
        [SerializeField]private float _speedEnemy;
        [SerializeField]private float _cdStarSpawnEnemy;
        [SerializeField]private float _intervalSpawnEnemy;
        [SerializeField]private float _countSpawnEnemy;
        [SerializeField]private float _countMine;
        
        public float SpeedPlayer => _speedPlayer;
        public float SpeedEnemy => _speedEnemy;
        public float CdStartSpawnEnemy => _cdStarSpawnEnemy;
        public float IntervalSpawnEnemy => _intervalSpawnEnemy;
        public float CountSpawnEnemy => _countSpawnEnemy;
        public float CountMine => _countMine;
    }
}

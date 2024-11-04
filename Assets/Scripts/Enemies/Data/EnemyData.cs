using UnityEngine;

namespace Powerfish.Enemy
{
    [CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data")]
    public class EnemyData : ScriptableObject
    {
        [Header("Chase State")]
        public float movementVelocity = 10f;
        public float rotationSpeed = 720f;
        public float playerDetectDistance = 30f;
        public LayerMask whatIsPlayer;
    }
}

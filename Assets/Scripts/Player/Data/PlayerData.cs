using UnityEngine;

namespace Powerfish.Player
{
    [CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Move State")]
        public float movementVelocity = 10f;
        public float rotationSpeed = 720f;
    }
}
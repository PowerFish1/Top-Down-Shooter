using UnityEngine;

namespace Powerfish.WeaponSystem.Components
{
    public class Damage : WeaponComponent
    {
        public float damageAmount;

        public override void ApplyEffect(GameObject target)
        {
            // Hedefe hasar uygula
            Debug.Log($"Dealing {damageAmount} damage to {target.name}");
        }
    }
}

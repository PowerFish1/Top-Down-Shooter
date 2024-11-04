using UnityEngine;

namespace Powerfish.WeaponSystem.Components
{
    public class Hitbox : WeaponComponent
    {
        public float hitboxRadius;

        public override void ApplyEffect(GameObject target)
        {
            // Vuru� kutusunu uygula
            Debug.Log($"Hitbox with radius {hitboxRadius} applied to {target.name}");
        }
    }
}

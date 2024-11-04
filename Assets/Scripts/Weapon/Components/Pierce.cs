using UnityEngine;

namespace Powerfish.WeaponSystem.Components
{
    public class Pierce : WeaponComponent<PierceData, AttackPierce>
    {
        public int penetrationPower;

        public override void ApplyEffect(GameObject target)
        {
            // Delici etkiyi uygula
            Debug.Log($"Applying piercing effect with power: {penetrationPower}");
        }
    }
}

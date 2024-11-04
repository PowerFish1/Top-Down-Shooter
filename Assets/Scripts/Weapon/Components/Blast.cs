using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerfish.WeaponSystem.Components
{
    public class Blast : WeaponComponent
    {
        public float blastRadius;
        public float damage;

        public override void ApplyEffect(GameObject target)
        {
            // Alan hasarýný uygula
            // Örneðin, etki alanýndaki tüm düþmanlarý etkiler
            Debug.Log($"Applying blast damage: {damage} in radius: {blastRadius}");
        }
    }
}

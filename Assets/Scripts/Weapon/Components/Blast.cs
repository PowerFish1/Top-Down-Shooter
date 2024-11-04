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
            // Alan hasar�n� uygula
            // �rne�in, etki alan�ndaki t�m d��manlar� etkiler
            Debug.Log($"Applying blast damage: {damage} in radius: {blastRadius}");
        }
    }
}

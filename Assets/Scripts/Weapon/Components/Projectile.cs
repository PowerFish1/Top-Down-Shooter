using UnityEngine;

namespace Powerfish.WeaponSystem.Components
{
    public class Projectile : WeaponComponent
    {
        public GameObject projectilePrefab;
        public float speed;

        public override void ApplyEffect(GameObject target)
        {
            // Proje baþlat
            GameObject projectile = Instantiate(projectilePrefab, target.transform.position, Quaternion.identity);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = target.transform.forward * speed;
            }

            Debug.Log($"Fired a projectile towards {target.name}");
        }
    }
}

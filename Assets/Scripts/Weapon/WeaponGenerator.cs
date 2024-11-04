using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Powerfish.WeaponSystem.Components;

namespace Powerfish.WeaponSystem
{
    public class WeaponGenerator : MonoBehaviour
    {
        [SerializeField] private Weapon weapon;
        private List<WeaponComponent> componentsAlreadyOnWeapon = new List<WeaponComponent>();
        private List<WeaponComponent> componentsAddedToWeapon = new List<WeaponComponent>();
        private List<Type> componentDependencies = new List<Type>();

        private void GenerateWeapon(WeaponData weaponData)
        {
            if (weaponData == null)
            {
                Debug.LogWarning("No WeaponData found on Weapon");
                return;
            }

            componentsAlreadyOnWeapon.Clear();
            componentsAddedToWeapon.Clear();
            componentDependencies.Clear();

            componentsAlreadyOnWeapon = GetComponents<WeaponComponent>().ToList();
            componentDependencies = weaponData.GetAllDependencies();

            foreach (var dependency in componentDependencies)
            {
                // If the component has the same dependency with the current WeaponData, continue
                if (componentsAddedToWeapon.FirstOrDefault(component => component.GetType() == dependency))
                {
                    continue;
                }

                // Check the component is already on the WeaponData or not
                var weaponComponent = componentsAlreadyOnWeapon.FirstOrDefault(component => component.GetType() == dependency);

                if (weaponComponent == null)
                {
                    weaponComponent = gameObject.AddComponent(dependency) as WeaponComponent;
                }

                weaponComponent.Init();
                componentsAddedToWeapon.Add(weaponComponent);
            }

            // Check for different components to remove
            var componentsToRemove = componentsAlreadyOnWeapon.Except(componentsAddedToWeapon);

            foreach (var weaponComponent in componentsToRemove)
            {
                Destroy(weaponComponent);
            }
        }

        private void Start()
        {
            if (weapon != null)
            {
                GenerateWeapon(weapon.weaponData);
            }
            else
            {
                Debug.LogWarning("Weapon is not assigned in WeaponGenerator.");
            }
        }

        private void OnEnable()
        {
            if (weapon != null)
            {
                weapon.OnWeaponDataChanged += GenerateWeapon;
            }
        }

        private void OnDestroy()
        {
            if (weapon != null)
            {
                weapon.OnWeaponDataChanged -= GenerateWeapon;
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using Powerfish.WeaponSystem.Components;
using System.Linq;
using System;

namespace Powerfish.WeaponSystem
{
    [CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/New Weapon")]
    public class WeaponData : ScriptableObject
    {
        public string weaponName;
        [field: SerializeReference] public List<ComponentData> componentData { get; private set; }

        public T GetData<T>()
        {
            return componentData.OfType<T>().FirstOrDefault();
        }

        public void AddData(ComponentData data)
        {
            if (componentData.FirstOrDefault(t => t.GetType() == data.GetType()) != null)
                return;

            componentData.Add(data);
        }

        public List<Type> GetAllDependencies()
        {
            return componentData.Select(component => component.ComponentDependency).ToList();
        }
    }
}
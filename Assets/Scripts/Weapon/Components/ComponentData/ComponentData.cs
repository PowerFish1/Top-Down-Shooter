using System;
using UnityEngine;

namespace Powerfish.WeaponSystem.Components
{
    [Serializable]
    public abstract class ComponentData
    {
        [SerializeField, HideInInspector] private string name;

        public Type ComponentDependency { get; protected set; }

        public ComponentData()
        {
            SetComponentName();
            SetComponentDependency();
        }

        public void SetComponentName() => name = GetType().Name;

        protected abstract void SetComponentDependency();
    }

    [Serializable]
    public abstract class ComponentData<T> : ComponentData where T : AttackData
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(T);
        }
    }
}
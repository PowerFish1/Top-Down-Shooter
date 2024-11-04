using Powerfish.CoreSystem;
using UnityEngine;

namespace Powerfish.WeaponSystem.Components
{
    public abstract class WeaponComponent : MonoBehaviour
    {
        protected Weapon weapon;
        protected Core core;
        
        public virtual void Init() {}
        
        protected virtual void Awake()
        {
            weapon = GetComponent<Weapon>();
        }
        
        public abstract void ApplyEffect(GameObject target);
    }

     public abstract class WeaponComponent<T1, T2> : WeaponComponent where T1 : ComponentData<T2> where T2 : AttackData
    {
        protected T1 data;

        public override void Init()
        {
            base.Init();

            data = weapon.weaponData.GetData<T1>();
        }
    }
}
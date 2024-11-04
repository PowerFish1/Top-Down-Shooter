using System.Collections.Generic;
using UnityEngine;

namespace Powerfish.WeaponSystem
{
    public class Inventory : MonoBehaviour
    {
        public List<WeaponData> weaponDataList; // Silah verilerinin listesi

        // Singleton pattern
        private static Inventory instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // 1: Pistol, 2: Rifle, 3: RPG
        public static WeaponData GetWeaponData(int weaponIndex)
        {
            if (weaponIndex >= 0 && weaponIndex < instance.weaponDataList.Count)
            {
                return instance.weaponDataList[weaponIndex];
            }

            return null; // Geçersizse null döndür
        }
    }
}

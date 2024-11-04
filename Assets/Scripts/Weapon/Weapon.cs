using UnityEngine;
using Powerfish.CoreSystem;
using Powerfish.Player;
using System;

namespace Powerfish.WeaponSystem
{
	public class Weapon : MonoBehaviour
	{
		[field: SerializeField] public WeaponData weaponData { get; private set; }
		public Core core { get; private set; }
		private PlayerInputHandler playerInputHandler;

		public event Action<WeaponData> OnWeaponDataChanged;

		private void Awake()
		{
			playerInputHandler = FindObjectOfType<PlayerInputHandler>();

			if (playerInputHandler != null)
			{
				playerInputHandler.OnWeaponChanged += UpdateWeaponData;
				UpdateWeaponData(playerInputHandler.previousChoice); // Başlangıçta silah verisini ayarla
			}
		}

		private void OnDestroy()
		{
			if (playerInputHandler != null)
			{
				playerInputHandler.OnWeaponChanged -= UpdateWeaponData; // Olay dinleyicisini kaldır
			}
		}

		public void SetCore(Core core)
		{
			this.core = core;
		}

		public void SetData(WeaponData weaponData)
		{
			this.weaponData = weaponData;

			if (this.weaponData is null)
				return;

			// WeaponGenerator is listening
			OnWeaponDataChanged?.Invoke(this.weaponData);
		}

		private void UpdateWeaponData(int weaponIndex)
		{
			WeaponData newWeaponData = Inventory.GetWeaponData(weaponIndex);
			SetData(newWeaponData);
		}
	}
}

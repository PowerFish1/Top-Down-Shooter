using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Powerfish.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 RawMovementInput { get; private set; }
        public Vector2 SmoothedMovementInput { get; private set; }
        private Vector2 SmoothVelocity;

        public int previousChoice { get; private set; } = 0; // Initially set to pistol
        public bool isShooting { get; private set; }
        public event Action<int> OnWeaponChanged;


        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed || context.started)
            {
                RawMovementInput = context.ReadValue<Vector2>();
            }
            else if (context.canceled)
            {
                RawMovementInput = Vector2.zero;
            }
        }

        public void OnWeaponChoice(InputAction.CallbackContext context)
        {

            if (context.started)
            {
                int choice = Convert.ToInt32(context.control.name);

                if (choice == previousChoice)
                    return;

                previousChoice = choice;

                OnWeaponChanged?.Invoke(choice - 1);

            }
        }


        public void OnShoot(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                isShooting = true;
            }
            if (context.canceled)
            {
                isShooting = false;
            }
        }

        private void FixedUpdate()
        {
            SmoothedMovementInput = Vector2.SmoothDamp(SmoothedMovementInput, RawMovementInput, ref SmoothVelocity, 0.1f);
        }


        /* public enum Weapons
        {
            pistol,
            rifle,
            rpg
        }
        */
    }
}

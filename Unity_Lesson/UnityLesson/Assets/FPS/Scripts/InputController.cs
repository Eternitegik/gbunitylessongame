using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPS
{
    public class InputController : BaseController
    {
        private void Update()
        {
            if (Input.GetButtonDown("SwitchFlashlight"))
            {
                Main.Instance.FlashlightController.SwitchFlashlight();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Main.Instance.WeaponsController.Fire();
            }

            var mswValue = Input.GetAxis("Mouse ScrollWheel");
            if (Mathf.Abs(mswValue) > 0.1f)
            {
                Main.Instance.WeaponsController.ChangeWeapon((int)Mathf.Sign(mswValue));
            }

            if (Input.GetButtonDown("TeamSet"))
            {
                Main.Instance.TeammateController.MoveCommand();
            }

            //if (Input.GetButtonDown("ReloadWeapon"))
            //{
            //    Main.Instance.WeaponsController.
            //}
        }
    }
}

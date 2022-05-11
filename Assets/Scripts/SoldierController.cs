using System;
using UnityEngine;
using UnityEngine.UI;

public class SoldierController : MonoBehaviour
{
    Soldier _soldier;
    [SerializeField] Text firingModeText;

    void Awake()
    {
        _soldier = GetComponent<Soldier>();
        
        _soldier.EquipGun(_soldier.gun);
        SetFiringMode(_soldier.gun.Mode);
    }

    void SetFiringMode(int index)
    {
        _soldier.gun.Mode = (int) _soldier.gun.modes[index];
        firingModeText.text = $"(X) Mode: {Enum.GetName(typeof(Gun.FiringMode), index)}";
    }
    
    void Update()
    {
        Gun gun = _soldier.gun;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (gun.State == Gun.GunState.Ready)
            {
                gun.Shoot();
            }

            return;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (gun.State == Gun.GunState.Shooting && gun.Mode == (int) Gun.FiringMode.Automatic)
            {
                gun.StopShooting();
            }

            return;
        }
        
        if (gun.State != Gun.GunState.Ready) return;
        //"Ready" state dependent keys
        if (Input.GetKeyDown(KeyCode.R))
        {
            gun.Reload();
            return;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            int nextIndex = gun.Mode + 1;
            if (nextIndex >= gun.modes.Length)
            {
                nextIndex = 0;
            }
            SetFiringMode(nextIndex);
        }
    }
}

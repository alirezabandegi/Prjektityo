using System;
using UnityEngine;
using UnityEngine.UI;

public class SoldierController : MonoBehaviour
{
    Soldier _soldier;
    [SerializeField] GameObject gunInfoCanvasPrefab;
    GunUI _gunUI;
    
    void Awake()
    {
        _soldier = GetComponent<Soldier>();
        _soldier.EquipGun(_soldier.gun);
    }

    void Start()
    {
        Debug.Assert(gunInfoCanvasPrefab.gameObject.scene.name == null, "Gun UI must be a prefab!");
        _gunUI = Instantiate(gunInfoCanvasPrefab).GetComponent<GunUI>();
        SetFiringMode(_soldier.gun.Mode);
    }

    void SetFiringMode(int index)
    {
        _soldier.gun.Mode = (int) _soldier.gun.modes[index];
        _gunUI.SetFiringMode(_soldier.gun.modes[_soldier.gun.Mode]);
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

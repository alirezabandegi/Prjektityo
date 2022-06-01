using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //Gun data
    [SerializeField] float fireRate, range, bulletSpeed; //fire rate i.e. fire cooldown is in seconds
    [SerializeField] int damage, ammo, magazineSize;
    [SerializeField] Bullet bullet;
    public Transform muzzle;

    public Soldier Soldier { get; set; }
    int EnemyLayer => Soldier.enemyLayer;
    
    AudioSource _source;
    Transform _gunTransform;
    
    bool CanShoot => State == GunState.Ready && Time.time > _nextShot;
    float _nextShot = 0f;

    public enum FiringMode
    {
        Automatic,
        Semiautomatic
    }

    public int Mode { get; set; } //indexes the modes array

    public FiringMode[] modes;

    //Gun states
    public enum GunState
    {
        Ready,
        Shooting,
        Reloading
    }

    public GunState State { get; private set; }

    //Functionality
    void Awake()
    {
        Mode = (int) modes[0]; //entry as the starting mode
        State = GunState.Ready;
        _source = GetComponent<AudioSource>();
        _gunTransform = transform;
    }

    void ShootBullet(Vector3 origin)
    {
        _nextShot = Time.time + fireRate;
        _source.PlayOneShot(_source.clip);
        GameObject bulletObject = Instantiate(this.bullet.gameObject, muzzle.position, muzzle.rotation);
        var newBullet = bulletObject.GetComponent<Bullet>();
        newBullet.damageLayer = EnemyLayer;
        newBullet.Propel(origin, bulletSpeed, range, damage);
    }

    IEnumerator FireAuto(Vector3 direction) //shoots multiple bullets until the gun's state isn't "shooting"
    {
        while (State == GunState.Shooting)
        {
            ShootBullet(direction);
            yield return new WaitForSeconds(fireRate);
        }
        _source.loop = false;
    }

    IEnumerator FireSemi(Vector3 direction) //shoots one bullet
    {
        ShootBullet(direction);
        yield return new WaitForSeconds(fireRate);
        StopShooting();
    }

    public void Shoot()
    {
        if (!CanShoot) return;
        State = GunState.Shooting;
        if (Mode == (int) FiringMode.Semiautomatic)
        {
            StartCoroutine(FireSemi(muzzle.forward));
        } else if (Mode == (int) FiringMode.Automatic)
        {
            StartCoroutine(FireAuto(muzzle.forward));
        }
    }

    public void ShootAt(Transform target)
    {
        if (!CanShoot) return;
        Vector3 targetDirection = (target.position - muzzle.position).normalized;
        StartCoroutine(FireSemi(targetDirection));
    }

    public void StopShooting()
    {
        State = GunState.Ready;
    }
    
    public void Reload()
    {
        State = GunState.Reloading;
        ammo = magazineSize;
    }
}
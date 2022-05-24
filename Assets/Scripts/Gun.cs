using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //Gun data
    [SerializeField] float damage, fireRate, range, bulletSpeed; //fire rate i.e. fire cooldown is in seconds
    [SerializeField] int ammo, magazineSize;
    [SerializeField] GameObject bulletObject;
    [SerializeField] Transform muzzle;
    AudioSource _source;
    Transform _gunTransform;

    float nextShot = 0f;

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

    void ShootBullet()
    {
        nextShot = Time.time + fireRate;
        _source.PlayOneShot(_source.clip);
        GameObject bullet = Instantiate(bulletObject, muzzle.position, muzzle.rotation);
        var rb = bullet.AddComponent<Rigidbody>(); //create rigidbodies with script so they are all identical
        rb.AddForce(transform.forward * bulletSpeed);
    }

    IEnumerator FireAuto() //shoots multiple bullets until the gun's state isn't "shooting"
    {
        while (State == GunState.Shooting)
        {
            ShootBullet();
            yield return new WaitForSeconds(fireRate);
        }
        _source.loop = false;
    }

    IEnumerator FireSemi() //shoots one bullet
    {
        ShootBullet();
        yield return new WaitForSeconds(fireRate);
        StopShooting();
    }

    public void Shoot()
    {
        if (State != GunState.Ready || Time.time < nextShot) return;
        nextShot = Time.time + fireRate;
        State = GunState.Shooting;
        if (Mode == (int) FiringMode.Semiautomatic)
        {
            StartCoroutine(FireSemi());
        } else if (Mode == (int) FiringMode.Automatic)
        {
            StartCoroutine(FireAuto());
        }
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
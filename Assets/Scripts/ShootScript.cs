using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Rigidbody Ammo;

    void Update()
    {
        
        if (Input.GetKey(KeyCode.Mouse0))
        { 
            Rigidbody clone;
            clone = Instantiate(Ammo, transform.position, transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.forward * 2000 * Time.deltaTime);
            Destroy(clone.gameObject, 4f);
        }
    }
}

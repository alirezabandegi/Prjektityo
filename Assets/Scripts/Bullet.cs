using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    Rigidbody _rb;
    public LayerMask damageLayer;
    readonly LayerMask _mapLayer = 1 << 7;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
    
    public void Propel(Vector3 direction, float bulletSpeed, float range, int damage)
    {
        _rb.AddForce(direction * bulletSpeed);
        if (Physics.Raycast(gameObject.transform.position, direction, out RaycastHit hitMap, range, _mapLayer))
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else
        {
            if (Physics.Raycast(gameObject.transform.position, direction, out RaycastHit hit, range, damageLayer))
            {
                var hitSoldier = hit.collider.gameObject.GetComponent<Soldier>();
                hitSoldier.HP -= damage;   
            }
        }

        float t = range / bulletSpeed;
        StartCoroutine(DestroyAfterSeconds(t));
    }
}
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
        if (Physics.Raycast(gameObject.transform.position, direction, out RaycastHit hit, range, damageLayer))
        {
            float distance = Vector3.Distance(hit.point, transform.position);
            if (Physics.Raycast(gameObject.transform.position, direction, out RaycastHit hitMap, distance, _mapLayer))
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else
            {
                print("Ready");
                var hitSoldier = hit.collider.gameObject.GetComponent<Soldier>();
                hitSoldier.HP -= damage;   
            }
        }
        _rb.AddForce(direction * bulletSpeed);

        float t = range / bulletSpeed;
        StartCoroutine(DestroyAfterSeconds(t));
    }
}
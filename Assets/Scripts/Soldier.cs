using UnityEngine;

public class Soldier : MonoBehaviour
{
    public Gun gun;
    public LayerMask enemyLayer;
    bool _gunEquipped;
    [SerializeField] Transform grip;
    public Transform spine;

    public void EquipGun(Gun newGun)
    {
        if (_gunEquipped)
        {
            Destroy(gun.gameObject);
        }

        _gunEquipped = true;
        gun = Instantiate(newGun, grip);
        gun.Soldier = this;
    }

    void Awake()
    {
        _gunEquipped = false;
    }
}

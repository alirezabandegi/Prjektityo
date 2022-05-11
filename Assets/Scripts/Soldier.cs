using UnityEngine;

public class Soldier : MonoBehaviour
{
    public Gun gun;
    bool _gunEquipped;
    [SerializeField] Transform grip;
    
    public void EquipGun(Gun newGun)
    {
        if (_gunEquipped)
        {
            Destroy(gun.gameObject);
        }

        _gunEquipped = true;
        gun = Instantiate(newGun, grip);
    }

    void Awake()
    {
        _gunEquipped = false;
    }
}

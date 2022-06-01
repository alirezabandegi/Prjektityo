using UnityEngine;

public class Soldier : MonoBehaviour
{
    public Gun gun;
    public LayerMask enemyLayer;
    bool _gunEquipped;
    [SerializeField] Transform grip;
    [SerializeField] int maxHP;
    int hp;
    public Transform spine;

    public int HP
    {
        get => hp;
        set
        {
            int newHP = Mathf.Clamp(value, 0, maxHP);
            hp = newHP;
            print(gameObject.name + "HP: " + newHP);
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

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

    void Start()
    {
        hp = maxHP;
    }
    
    void Awake()
    {
        _gunEquipped = false;
    }
}

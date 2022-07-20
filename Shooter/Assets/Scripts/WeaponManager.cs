using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    OneShot,
    DoubleShot
}
public class WeaponManager : MonoBehaviour
{
    
    public GameObject oneShotBullet;
    public GameObject doubleShotBullet;

    GameObject myBullet;

    IWeapon weapon;

    //MyBullet myBullet;

    void SetWeaponType(WeaponType weaponType)
    {
        Component c = gameObject.GetComponent<IWeapon>() as Component;

        if (c != null) Destroy(c);

        switch (weaponType)
        {
            case WeaponType.OneShot:
                weapon = gameObject.AddComponent<OneShot>();
                myBullet = oneShotBullet;
                break;
            case WeaponType.DoubleShot:
                weapon = gameObject.AddComponent<DoubleShot>();
                myBullet = doubleShotBullet;
                break;
        }
    }

    void Start() => SetWeaponType(WeaponType.OneShot);
    public void ChangeToBullet(WeaponType weaponType) => SetWeaponType(weaponType);
    public void Fire(GameObject player) => weapon.Shoot(myBullet, player);
}

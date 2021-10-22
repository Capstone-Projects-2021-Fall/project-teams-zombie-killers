using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;

    public void Shoot()
    {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }
}

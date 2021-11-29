using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFire : MonoBehaviour
{

    [SerializeField] private float damage;
    [SerializeField] private float damageFrequency;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DealFireDamage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DealFireDamage()
    {
        while (this)
        {
            yield return new WaitForSeconds(damageFrequency);
            Zombie parentZombie = GetComponentInParent<Zombie>();
            if (parentZombie)
            {
                parentZombie.takeDamage(damage);
            }
        }
    }
}

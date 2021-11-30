using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedDefenderTrigger : MonoBehaviour
{
    [Header("Projectile shot by the ranged defender")]
    public GameObject projectilePrefab;

    [Header("Damage that will be dealt by projectile")]
    [SerializeField] private float damage;

    [Header("The defender will only shoot defenders in this range.")]
    [SerializeField] private int range;

    [Header("How many seconds the defender waits until it shoots again.")]
    [SerializeField] private float shootSpeed;


    private int zombiesInRange = 0;


    void Awake()
    {
        projectilePrefab.GetComponent<Projectile>().damage = damage;
        projectilePrefab.GetComponent<Projectile>().range = range;

        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.size = new Vector2( (range+1) * 1.2f, 0.4f);
        collider.offset = new Vector2( range * 0.6f, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks that it was an Enemy that entered the 2D Collier
        //Then checks that there wasn't already a zombie in the range
        if(collision.CompareTag("Enemy") && zombiesInRange++ == 0)
            StartCoroutine(repeatedShootProjectile());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            zombiesInRange -= 1;
    }


    #region Shoot Functions
    IEnumerator repeatedShootProjectile()
    {
        while (zombiesInRange > 0)
        {
            shootProjectile();
            yield return new WaitForSeconds(shootSpeed);
        }
    }

    protected void shootProjectile()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, transform);
    }
    #endregion
}

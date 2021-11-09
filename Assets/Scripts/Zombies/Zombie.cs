using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] int reward = 10;
    [Range (0f, 5f)]
    [SerializeField] float walkSpeed = 1f;
    [SerializeField] private float baseStartingHealth;
    protected float startingHealth
    {
        get { return baseStartingHealth; }
        set { baseStartingHealth = value; }
    }
    protected float currentHealth;
    [SerializeField] private float damage;
    [SerializeField] private float attackRefresh;
    private bool isAttacking = false;

    private void Awake()
    {
        ProgressController.singleton.ZombieSpawned();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    private void OnDestroy()
    {
        
        FindObjectOfType<StarDisplay>().AddStars(reward);
        ProgressController.singleton.ZombieKilled();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAttacking)
            transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
    }

    #region Box Collider Functions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DefenderProjectile"))
        {
            takeDamage(collision.gameObject.GetComponent<Projectile>().damage);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Defender"))
        {
            isAttacking = true;
            //Destroy(collision.gameObject);
            Defender defender = collision.gameObject.GetComponent<Defender>();
            if (defender != null)
                StartCoroutine(Attack(defender));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Defender"))
        {
            isAttacking = false;
        }
    }
    #endregion

    public void takeDamage(float damage)
    {
        this.currentHealth = currentHealth - damage;
        if (this.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Attack(Defender defender)
    {
        while (this)
        {
            yield return new WaitForSeconds(attackRefresh);
            defender.takeDamage(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Projectile : MonoBehaviour
{
    [Header("This value is the how many units to the right the projectile moves each second")]
    [SerializeField] private float speed;
    public float damage;
    public float range = 15;

    private float outsideRange;

    void Awake()
    {
        outsideRange = range * 1.2f - 0.6f;
        StartCoroutine(ProjectileRotate());
    }


     
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        if (transform.localPosition.x >= outsideRange)
            killSelf();
    }

    IEnumerator ProjectileRotate()
    {
        while(this)
        {
            yield return new WaitForSeconds(0.1f);
            transform.Rotate(0f, 0f, transform.rotation.z + 15f);
        }
    }

    void killSelf()
    {
        Destroy(gameObject);
    }

}

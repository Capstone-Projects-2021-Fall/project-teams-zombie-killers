using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Projectile : MonoBehaviour
{
    [Header("This value is the amount of time (in seconds) it takes for the projectile to reach end of screen")]
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Awake()
    {
        ProjectileMove();
        StartCoroutine(ProjectileRotate());
    }

    void ProjectileMove()
    {
        transform.DOMoveX(15, speed).OnComplete(killSelf);
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

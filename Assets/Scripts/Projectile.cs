using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Awake()
    {
        ProjectileMove();
        StartCoroutine(ProjectileRotate());
    }

    void ProjectileMove()
    {
        transform.DOLocalMoveX(5, speed).OnComplete(killSelf);
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

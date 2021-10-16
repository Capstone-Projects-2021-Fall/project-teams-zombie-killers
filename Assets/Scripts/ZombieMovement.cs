using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed += Random.Range(-0.1f, 0.1f);
        StartCoroutine(ZombieMove());
    }

    IEnumerator ZombieMove()
    {
        int endOfBoardCounter = 0;
        while (endOfBoardCounter != 10)
        {
            yield return new WaitForSeconds(speed);
            if (gameObject != null)
            {
                transform.DOMoveX(transform.position.x - 1, speed);
                endOfBoardCounter++;
            }
        }
        Destroy(gameObject);
    }
}

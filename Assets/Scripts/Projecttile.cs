using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecttile : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

}

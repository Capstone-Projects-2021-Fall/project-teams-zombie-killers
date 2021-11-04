using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        FindObjectOfType<Lives>().TakeLife();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [Range (0f, 5f)]
    [SerializeField] float walkSpeed = 1f;

    private void Awake()
    {
        FindObjectOfType<ProgressController>().ZombieSpawned();
    }

    private void OnDestroy()
    {
        FindObjectOfType<ProgressController>().ZombieKilled();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Fireball fireballPrefab;
    public Transform fireballSpawnerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireballSpawn();
    }

    private void fireballSpawn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fireballPrefab, fireballSpawnerTransform.position, fireballSpawnerTransform.rotation);
        }
    }
}

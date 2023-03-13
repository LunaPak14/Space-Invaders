using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemyBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    
    void Update()
    {
        if (!(bulletPrefab is null))
        {
            Random random = new Random();
            if (random.Next(1000000) <= 200)
            {
                GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
                Destroy(shot, 3f);
            }
        }
    }
}

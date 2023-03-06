using System;
using UnityEngine;
using Random = System.Random;

public class EnemyComplete : MonoBehaviour
{
    //random fire variables
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    
    //event variables
    public delegate void EnemyDestroyed(int enemyValue);
    public static event EnemyDestroyed OnEnemyAboutToBeDestroyed;
    
    //animation variable
    private Animator enemyAnimator;

    // value of enemy variable
    public int enemyValue;

    //-----------------------------------------------------------------------------
    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Bullet(Clone)")
        {
            OnEnemyAboutToBeDestroyed.Invoke(enemyValue);
            Destroy(col.gameObject); // destroy bullet
            enemyAnimator.SetTrigger("Shoot Trigger");
            Destroy(this.gameObject);
            PlayerPrefs.SetInt("enemies", PlayerPrefs.GetInt("enemies") + 10);
        }
    }

    private void Update()
    {
        if (!(bulletPrefab is null))
        {
            Random random = new Random();
            if (random.Next(1000000) <= 100)
            {
                GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
                Destroy(shot, 3f);
            }
        }
    }
}

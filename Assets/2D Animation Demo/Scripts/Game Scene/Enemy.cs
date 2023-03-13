using System;
using System.Collections;
using UnityEngine;

public class EnemyComplete : MonoBehaviour
{

    //event variables
    public delegate void EnemyDestroyed(int enemyValue);
    public static event EnemyDestroyed OnEnemyAboutToBeDestroyed;
    
    //animation & audio variable
    private Animator enemyAnimator;
    public AudioSource deathEnemy;

    // value of enemy variable
    public int enemyValue;

    //-----------------------------------------------------------------------------
    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    private IEnumerator OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Bullet(Clone)")
        {
            OnEnemyAboutToBeDestroyed.Invoke(enemyValue);
            Destroy(col.gameObject); // destroy bullet
            enemyAnimator.SetTrigger("Shoot Trigger");
            deathEnemy.Play();
            yield return new WaitForSeconds(2);
            Destroy(this.gameObject);
            PlayerPrefs.SetInt("enemies", PlayerPrefs.GetInt("enemies") + 10);
        }
    }
}

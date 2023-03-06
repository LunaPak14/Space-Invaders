using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Barrier : MonoBehaviour
{
    private Animator barrierAnimator;
    private int health;
    
    // Start is called before the first frame update
    void Start()
    {
        barrierAnimator = GetComponent<Animator>();
        health = 100;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            health -= 10;
            Destroy(col.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        if (health == 60 || health == 20)
            barrierAnimator.SetTrigger("Health Trigger");
        if (health == 0)
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

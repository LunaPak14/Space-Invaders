using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    private Vector3 direction = Vector3.left;
    
    private int enemiesLeft;
    public float timeMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("enemies", 24);
        enemiesLeft = PlayerPrefs.GetInt("enemies", 24);
        timeMovement = (float)enemiesLeft / 80;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesLeft = PlayerPrefs.GetInt("enemies", 24);
        timeMovement = (float)enemiesLeft / 80;
        transform.position += direction * timeMovement * Time.deltaTime;
        Vector3 position = transform.position;
        if (transform.position.x <= -9.5 && direction == Vector3.left)
        {
            position.y -= 0.5f;
            direction = Vector3.right;
        }

        if (transform.position.x >= 4.5 && direction == Vector3.right)
        {
            position.y -= 0.5f;
            direction = Vector3.left;
        }

        transform.position = position;
    }
}

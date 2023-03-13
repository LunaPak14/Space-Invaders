using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMenu : MonoBehaviour
{
    private Vector3 direction;
    private float pos;
    private float pos2;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.left;
        pos = 9f;
        pos2 = -9f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime;
        if (direction == Vector3.right && transform.localPosition.x >= pos)
            direction = Vector3.left;
        if (direction == Vector3.left && transform.localPosition.x <= pos2)
            direction = Vector3.right;
    }
}

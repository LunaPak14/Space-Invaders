using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("bullet")] public GameObject bulletPrefab;
    [FormerlySerializedAs("shottingOffset")] public Transform shootOffsetTransform;

    public float moveSpeed = 10f;
    private Animator playerAnimation;
    public AudioSource deathAudio;

    //-----------------------------------------------------------------------------
    private void Start()
    {
        playerAnimation = GetComponent<Animator>();
        GetComponentInChildren<ParticleSystem>().Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimation.SetTrigger("Player Shoots");
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            Destroy(shot, 3f);
        }
        float movement = Input.GetAxis ("Horizontal") * moveSpeed;
        transform.position += Vector3.right * movement * Time.deltaTime;
    }

    private IEnumerator OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name != "Bullet(Clone)")
        {
            Destroy(col.gameObject);
            playerAnimation.SetTrigger("Shoot Trigger");
            deathAudio.Play();
            yield return new WaitForSeconds(3.5f);
            SceneManager.LoadScene("Credits", LoadSceneMode.Single);
        }
    }
}

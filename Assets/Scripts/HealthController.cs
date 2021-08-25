using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    Camera cam;
    public AudioSource crunchSound;

    private void Awake()
    {
        cam = Camera.main;
    }
     
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 1f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

         crunchSound.Play(); 
         Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0f);
            cam.orthographicSize += 0.15f;

         collision.gameObject.transform.localScale += scaleChange;

            Destroy(gameObject);
        }
    }
}

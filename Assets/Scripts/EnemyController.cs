using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed;
    public Transform target;
    public AudioSource crunchSound, deathSound; 
    public GameObject losePanel;
    public KatkootController katkootController;
    Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            float enemyScale = gameObject.transform.localScale.x;
            float katkootScale = collision.gameObject.transform.localScale.x;

            if (enemyScale > katkootScale)
            {
                //Kill Player & Play Oof Sound & Show Retry/Go2Menu
                deathSound.Play();
                Destroy(collision.gameObject);
                losePanel.SetActive(true);
            }
            else
            {
                crunchSound.Play();
                Vector3 scaleChange = new Vector3(0.15f, 0.15f, 0f);

                collision.gameObject.transform.localScale += scaleChange; 
                cam.orthographicSize += 0.15f;

                Destroy(gameObject);
                katkootController.WinCalculator();
            }
        }
    }
 

}

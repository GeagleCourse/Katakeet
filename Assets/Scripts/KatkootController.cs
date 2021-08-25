using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatkootController : MonoBehaviour
{

    Rigidbody2D rigidbody;
    public int katSpeed;
    float horizontalMovement, verticalMovement;
    public GameObject winPanel, winConfetti;
    public int enemyCounter;
     
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
     
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        rigidbody.AddForce(new Vector2(horizontalMovement, verticalMovement) * katSpeed * Time.deltaTime); 
    }

    public void WinCalculator()
    {
        enemyCounter--;
        if (enemyCounter <= 0)
        {
            winPanel.SetActive(true);
            winConfetti.SetActive(true);
        }
    } 
}


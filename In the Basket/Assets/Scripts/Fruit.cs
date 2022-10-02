using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [Header("Speed Settings")]
    public float minSpeed;
    public float maxSpeed;
    private float speed;

    [Header("Score Settings")]
    public int scoreGiven;

    [Header("Effects")]
    public GameObject Explosion;
 
    Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.tag == "Player")
        {
            playerScript.increaseScore(scoreGiven);
            
            Destroy(gameObject);
        }

        if (hitObject.tag == "Ground")
        {
            playerScript.TakeDamage(1);
            Instantiate(Explosion, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}

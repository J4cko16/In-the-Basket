using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Score
{
    private Vector2 targetPos;
    
    [HideInInspector]
    public int score;

    [Header("Stats")]
    public int health;

    [Header("Movement Settings")]
    public float movementDistance;
    public float minX;
    public float maxX;

    [Header("UI")]
    public TMP_Text scoreDisplay;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject losePanel;

    [Header("Effects")]
    public GameObject Camera;
    public float movementShakeDuration;
    public float hurtShakeDuration;
    public GameObject mainSpawner;
    public GameObject Music;
    public GameObject EventSpawner;

    [Header("Music")]
    public AudioSource audioSource;
    public AudioClip walk;

    private Animator anim;
    private bool dead = false;

    public void Awake()
    {
        anim = GetComponent<Animator>();;
    }

    public void Update()
    {
        UpdateHealthUI(health);

        if (dead == false)
        {
            if ((Input.GetKeyDown(KeyCode.A) && transform.position.x > minX))
            {
                targetPos = new Vector2(transform.position.x - movementDistance, transform.position.y);
                StartCoroutine(Camera.GetComponent<Shake>().Shaking(movementShakeDuration));
                transform.position = targetPos;

                audioSource.PlayOneShot(walk);
            }

            if ((Input.GetKeyDown(KeyCode.D) && transform.position.x < maxX))
            {
                targetPos = new Vector2(transform.position.x + movementDistance, transform.position.y);
                StartCoroutine(Camera.GetComponent<Shake>().Shaking(movementShakeDuration));
                transform.position = targetPos;

                audioSource.PlayOneShot(walk);
            }

            if ((Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > minX))
            {
                targetPos = new Vector2(transform.position.x - movementDistance, transform.position.y);
                StartCoroutine(Camera.GetComponent<Shake>().Shaking(movementShakeDuration));
                transform.position = targetPos;

                audioSource.PlayOneShot(walk);
            }

            if ((Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < maxX))
            {
                targetPos = new Vector2(transform.position.x + movementDistance, transform.position.y);
                StartCoroutine(Camera.GetComponent<Shake>().Shaking(movementShakeDuration));
                transform.position = targetPos;

                audioSource.PlayOneShot(walk);
            }
        }
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            highScoreDisplay.text = score.ToString();
        }

        scoreDisplay.text = score.ToString();
    }

    public void increaseScore (int scoreAdded)
    {
        score = score + scoreAdded;
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;

        if (health <= 0)
        {
            StartCoroutine(End());
        } else
        {
            StartCoroutine(Camera.GetComponent<Shake>().Shaking(hurtShakeDuration));           
        }
    }

    void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public IEnumerator End()
    {
        dead = true;

        mainSpawner.SetActive(false);
        EventSpawner.SetActive(false);
        Music.SetActive(false);

        GameObject[] fruit = GameObject.FindGameObjectsWithTag("fruit");
        foreach (GameObject item in fruit)
            GameObject.Destroy(item);

        GameObject fruitEvent = GameObject.FindGameObjectWithTag("event");
        GameObject.Destroy(fruitEvent);

        anim.SetTrigger("end");

        yield return new WaitForSeconds(.5f);

        StartCoroutine(Camera.GetComponent<Shake>().Shaking(2));

        yield return new WaitForSeconds(3f);

        losePanel.SetActive(true);

    }
}

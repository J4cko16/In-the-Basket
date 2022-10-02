using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventManager : MonoBehaviour
{
    [Header("Events")]
    public GameObject[] Events;
    public GameObject[] harderEvents;
    public GameObject[] extremeEvents;
    public TMP_Text Timer;

    private bool harderEventToggle = false;
    private int extremeEventCountdown = 0;

    [Header("Settings")]
    public GameObject standardSpawner;

    [Header("UI")]
    public GameObject nextEventText;
    public GameObject eventEndText;
   
    public GameObject day;
    public GameObject night;

    private float timeBtwSpawns;
    private float startTimeBtwSpawns = 10;
    private float eventTimer = 10;

    private float countdownAsSec;
    private float countdownAsSecc;
    private bool eventInProgress = false;

    void Start()
    {
        timeBtwSpawns = 10;

        eventTimer = 10;
    }

    void Update()
    {
        if (eventInProgress == false)
        {
            if (timeBtwSpawns <= 0)
            {
                if (extremeEventCountdown >= 2)
                {
                    GameObject extremeRandomEvent = extremeEvents[Random.Range(0, extremeEvents.Length)];
                    Instantiate(extremeRandomEvent, transform.position, Quaternion.identity);
                } else
                {
                    if (harderEventToggle == false)
                    {
                        GameObject randomEvent = Events[Random.Range(0, Events.Length)];
                        Instantiate(randomEvent, transform.position, Quaternion.identity);

                        harderEventToggle = true;
                    }
                    else
                    {
                        GameObject harderRandomEvent = harderEvents[Random.Range(0, Events.Length)];
                        Instantiate(harderRandomEvent, transform.position, Quaternion.identity);

                        extremeEventCountdown = extremeEventCountdown + 1;
                    }
                }              

                eventInProgress = true;

                eventTimer = startTimeBtwSpawns;

                night.SetActive(true);
                day.SetActive(false);

                GameObject[] fruit = GameObject.FindGameObjectsWithTag("fruit");
                foreach (GameObject item in fruit)
                    GameObject.Destroy(item);
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;

                countdownAsSec = Mathf.FloorToInt(timeBtwSpawns % 60);
                Timer.text = (countdownAsSec.ToString());

                eventEndText.SetActive(false);
                nextEventText.SetActive(true);
            }
        } else
        {
            if (eventTimer <= 0)
            {
                standardSpawner.SetActive(true);
                eventInProgress = false;

                GameObject[] fruit = GameObject.FindGameObjectsWithTag("fruit");
                foreach (GameObject item in fruit)
                    GameObject.Destroy(item);

                night.SetActive(false);
                day.SetActive(true);

                GameObject fruitEvent = GameObject.FindGameObjectWithTag("event");                
                    GameObject.Destroy(fruitEvent);

                timeBtwSpawns = startTimeBtwSpawns;
            } else
            {
                eventTimer -= Time.deltaTime;

                eventEndText.SetActive(true);
                nextEventText.SetActive(false);

                countdownAsSecc = Mathf.FloorToInt(eventTimer % 60);
                Timer.text = (countdownAsSecc.ToString());

                standardSpawner.SetActive(false);
            }
        }
    }
}


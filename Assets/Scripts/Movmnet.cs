using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movmnet : MonoBehaviour
{
    private Joystick joystick;
    private Rigidbody rb;
    [SerializeField] private float MoveSpeed;


    [SerializeField] float timeLeft;
    [SerializeField] bool timerOn;
    [SerializeField] Text timmerText;
    [SerializeField] UIManager uIManager;
    private float seconds;

    public bool GameResume;

    public ScoreManager scoreManager;

    void Start()
    {
        Time.timeScale = 1;
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        rb = GetComponent<Rigidbody>();
        timerOn = true;
        GameResume = true;
        scoreManager = GetComponent<ScoreManager>();
    }
    void Update()
    {
        if (GameResume == true)
        {
            if (timerOn)
            {
                if (timeLeft > 0)
                {
                    timeLeft -= Time.deltaTime;
                    UpdateTimer(timeLeft);                                    
                }
                else
                {
                    // this will happen when time runs over

                    timeLeft = 0;
                    timerOn = false;
                    GameResume = false;
                    rb.velocity = Vector3.zero;
                    Time.timeScale = 0;
                    uIManager.FinishArea();
                }
            }
        }
           
    }

    public void FixedUpdate()
    {
        if (GameResume == true)
        {
            float horizontal = joystick.Horizontal;
            float vertical = joystick.Vertical;

            if (Input.GetMouseButton(0))
            {
                // movepseed = 1000 first
                if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
                {
                    transform.rotation = Quaternion.Euler(0f, (Mathf.Atan2(horizontal * 180, vertical * 180) * Mathf.Rad2Deg), 0f);
                    // the higher the score the higher the speed
                    if (scoreManager.Scorevalue() == true)
                    {
                        rb.velocity = MoveSpeed * 1.35f * Time.fixedDeltaTime * transform.forward;
                    }
                    else
                    {
                        rb.velocity = MoveSpeed * Time.fixedDeltaTime * transform.forward;
                    }
                }
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        seconds = Mathf.FloorToInt(currentTime % 60);

        TimmerUpdatter();
    }

    public void TimmerUpdatter()
    {
        timmerText.text = seconds.ToString();
    }
}

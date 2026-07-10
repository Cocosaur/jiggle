using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class S_unicornCollector : MonoBehaviour
{

    private int unicornCount;
    public int unicornObjective = 3;

    public float countdown = 3f;
    public float countdownStartValue;
    private bool countingDown;
    public bool gameWon;
    public bool wakeThemUp;
    

    //public S_unicornMovement uniMovement;


    public TextMeshProUGUI countText;
    public TextMeshProUGUI timerText;


    public GameObject Win;
    public GameObject Wait;
    public GameObject TooMany;
    public GameObject RestartButton;
    public GameObject timerTextObject;

    public List<GameObject> unicornsInTrigger = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("unicornObject"))
        {
            if (!unicornsInTrigger.Contains(other.gameObject))
            {
                unicornsInTrigger.Add(other.gameObject);

                unicornCount++;
                SetCountText();
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (unicornsInTrigger.Contains(other.gameObject))
        {
            unicornsInTrigger.Remove(other.gameObject);
            unicornCount--;
            SetCountText();
        }
    }

    void SetCountText()
    {
        if (wakeThemUp)
        {
            countText.text = "in bed " + unicornObjective + "/" + unicornCount.ToString();
            CheckCount();
        }

        countText.text = "in bed " + unicornCount.ToString() + "/" + unicornObjective;
        CheckCount();
    }

    void SetTimerText()
    {

        timerText.text = countdown.ToString("0");
    }

    void CheckCount()
    {
        if (wakeThemUp)
        {
            unicornObjective = 0;
            
            TooMany.SetActive(false);
            
            StartCountdown();
        }

        if (unicornCount == unicornObjective)
        {
            TooMany.SetActive(false);
            
            StartCountdown();
        }

        if (unicornCount > unicornObjective)
        {
            Wait.SetActive(false);
            TooMany.SetActive(true);
            Win.SetActive(false);
            
            StopCountdown();

        }

        if (unicornCount < unicornObjective)
        {

            Wait.SetActive(false);
            TooMany.SetActive(false);
            Win.SetActive(false);
            
            StopCountdown();

        }
    }

    public void StartCountdown()
    {
        if (wakeThemUp)
        {
            countingDown = false;
            countdownStartValue = 0f;
            
            Wait.SetActive(false);
            timerTextObject.SetActive(false);
            
            EndOfRound();
        }

        countingDown = true;
        countdown = countdownStartValue;
        
        Wait.SetActive(true);
        timerTextObject.SetActive(true);
        
    }

    public void StopCountdown()
    {
        countingDown = false;
        timerTextObject.SetActive(false);
    }

    void CountdownUpdate()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f)
        {
            countdown = 0;
            EndOfRound();
        }
        
        SetTimerText();
    }

    public void EndOfRound()
    {
        gameWon = true;
        Win.SetActive(true);
        Wait.SetActive(false);
        TooMany.SetActive(false);
        RestartButton.SetActive(true);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    
    public void ToLevel2()
    {
        SceneManager.LoadScene(2);
    }
    
    public void ToLevel3()
    {
        SceneManager.LoadScene(3);
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            WakeThoseLittleShits();
        }

        SetCountText();
        SetTimerText();
        StartCountdown();
        Win.SetActive(false);
        Wait.SetActive(false);
        TooMany.SetActive(false);
        RestartButton.SetActive(false);
        timerTextObject.SetActive(false);
    }
    
    void WakeThoseLittleShits()
    {
        wakeThemUp = true;
    }

    private void Update()
    {
        if (gameWon)
        {
            return;
        }

        
        
        if (countingDown)
        {
            CountdownUpdate();
        }
    }

    
}

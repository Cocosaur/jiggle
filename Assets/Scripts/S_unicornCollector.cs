using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class S_unicornCollector : MonoBehaviour
{

    private int unicornCount;
    public int unicornObjective = 3;
    public float elapsedTime;
    
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timerText;


    public GameObject Win;
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
        countText.text = "in bed " + unicornCount.ToString() + "/" + unicornObjective;
        CheckCount();
    }

    void SetTimerText()
    {
        timerText.text = elapsedTime.ToString();
    }

    void CheckCount()
    {
        if (unicornCount == unicornObjective)
        {
            Win.SetActive(true);
            TooMany.SetActive(false);
            RestartButton.SetActive(true);
            timerTextObject.SetActive(true);
            //StartCountdown();
            //SetTimerText();

        }

        if (unicornCount > unicornObjective)
        {
            Win.SetActive(false);
            TooMany.SetActive(true);
            //timerTextObject.SetActive(false);
            print("the countdown has stopped");

        }
        
        if (unicornCount < unicornObjective)
        {
            Win.SetActive(false);
            TooMany.SetActive(false);
            //timerTextObject.SetActive(false);
            print("the countdown has stopped");

        } 
    }

    public void StartCountdown()
    {
        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime / 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Start()
    {
        SetCountText();
        SetTimerText();
        StartCountdown();
        Win.SetActive(false);
        TooMany.SetActive(false);
        RestartButton.SetActive(false);
        timerTextObject.SetActive(true);
    }
    
}

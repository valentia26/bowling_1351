using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class BowlingScoreManager : MonoBehaviour
{
    public static BowlingScoreManager instance;

    [SerializeField]
    private List<GameObject> pins; // ลาก Pin ทั้ง 6 ตัวมาใส่

    [SerializeField]
    private TMP_Text resultText;

    [SerializeField]
    private float fallenAngleThreshold = 40f;

    [SerializeField]
    private float checkDelay = 3f;

    [Header("End Game UI")]
    [SerializeField]
    private GameObject endGamePanel; 

    private bool hasChecked = false;

    void Awake()
    {
        instance = this;

        if (endGamePanel != null)
            endGamePanel.SetActive(false); 
    }

    public void CheckStrike()
    {
        if (hasChecked) return;
        hasChecked = true;

        Invoke(nameof(EvaluatePins), checkDelay);
    }

    private void EvaluatePins()
    {
        int fallenCount = 0;

        foreach (GameObject pin in pins)
        {
            if (pin == null)
            {
                fallenCount++;
                continue;
            }

            float xAngle = pin.transform.eulerAngles.x;
            float zAngle = pin.transform.eulerAngles.z;

            if (xAngle > 180f) xAngle -= 360f;
            if (zAngle > 180f) zAngle -= 360f;

            if (Mathf.Abs(xAngle) > fallenAngleThreshold || Mathf.Abs(zAngle) > fallenAngleThreshold)
            {
                fallenCount++;
            }
        }

        bool isStrike = fallenCount >= pins.Count;

        if (resultText != null)
        {
            resultText.text = isStrike
                ? "STRIKE! 🎳"
                : $" {fallenCount}/{pins.Count} pins";
        }

        Debug.Log(isStrike ? "STRIKE!" : $" {fallenCount} from {pins.Count} pins");

       
        ShowEndGamePanel();
    }

    private void ShowEndGamePanel()
    {
        if (endGamePanel != null)
            endGamePanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResetCheck()
    {
        hasChecked = false;
    }
}
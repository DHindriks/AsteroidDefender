using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;

    [SerializeField] TextMeshProUGUI Score;

    int CurrentScore;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void AddScore(int Amount)
    {
        CurrentScore += Amount;
        Score.text = CurrentScore.ToString();
    }
}

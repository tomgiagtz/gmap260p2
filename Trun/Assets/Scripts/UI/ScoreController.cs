using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreField;
    // Start is called before the first frame update
    void Start()
    {
        scoreField = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        float score = Mathf.Floor(LevelController.globalTime * 10f);
        string scoreText = score.ToString();
        for (int i = 0; scoreText.Length < 4; i++) {
            scoreText = "0" + scoreText;
        }
        scoreField.SetText(scoreText);
    }
}

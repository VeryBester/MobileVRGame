using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public Image bgRing;
    public Image greenRing;
    public Text scoreText;

    private int score;
    private int maxScore = 100;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScore(int score)
    {
        this.score = score;
        refreshDisplay();
    }

    public void refreshDisplay()
    {
        greenRing.fillAmount = score / maxScore;
        scoreText.text = score.ToString();
    }
}

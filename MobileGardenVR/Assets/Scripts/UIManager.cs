using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public Image bgRing;
    public Image greenRing;
    public Text scoreText;
    public Text carrotText;
    public Text appleText;
    public Text tomatoText;

    private int score;
    private int maxScore = 100;

    public PlayerStats player;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        carrotText.text = player.plantCount.ToString();
        tomatoText.text = player.plantCount.ToString();
        appleText.text = player.appleCount.ToString();

        setScore(player.score);
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

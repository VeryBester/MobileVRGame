using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    // Ring UI
    public Image bgRing;
    public Image greenRing;
    public Text scoreText;

    // Score UI
    public Text carrotText;
    public Text appleText;
    public Text tomatoText;

    // Tool UI
    public Slider toolbar;
    public Text toolbarText;
    public GameObject winBoard;

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
        if (player.currTool.name == "Water")
        {
            showToolbar();
            setToolbar(player.water, 1);
        }

        carrotText.text = player.plantCount.ToString();
        appleText.text = player.appleCount.ToString();

        setScore(player.score);

        if(player.score >= 100)
        {
            winBoard.SetActive(true);
        }
    }

    public void setScore(int score)
    {
        this.score = score;
        refreshDisplay();
    }

    public void showToolbar()
    {
        toolbar.gameObject.SetActive(true);
        toolbarText.gameObject.SetActive(true);
    }

    public void hideToolbar()
    {
        toolbar.gameObject.SetActive(false);
        toolbarText.gameObject.SetActive(false);
    }

    public void setToolbar(float amount, int maxAmount)
    {
        toolbar.maxValue = maxAmount;
        toolbar.value = amount;
        toolbarText.text = player.currTool.name;
    }

    public void refreshDisplay()
    {
        greenRing.fillAmount = score / maxScore;
        scoreText.text = score.ToString();
    }
}

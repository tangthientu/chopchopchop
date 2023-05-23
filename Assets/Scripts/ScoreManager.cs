using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    int _score;
    [SerializeField]
    float _comboCounter;
    [SerializeField]
    float _maxCombo;
    [SerializeField]
    float gameTime;
    [SerializeField]
    int difficulty;
    public DeadZone deadZone;
    public Slider comboSlider;
    public Gradient gradient;
    public Image fill;
    
    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }
    public float ComboCounter
    {
        get { return _comboCounter; }
        set { _comboCounter = value; }

    }

    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        _maxCombo = 5;
        _comboCounter = _maxCombo;
        
    }

    // Update is called once per frame
    void Update()
    {
        comboSlider.maxValue = _maxCombo;
        comboSlider.value = ComboCounter;
        fill.color = gradient.Evaluate(comboSlider.normalizedValue);
        scoreText.text = _score.ToString();
        //Combo Counter
        gameTime += 1 * Time.deltaTime;
        if(gameTime>0)
        {
            difficulty = 1;
        }
        if (gameTime > 25)
        {
            difficulty = 2;
        }
        if (gameTime > 50)
        {
            difficulty = 3;
        }
        if (_comboCounter <= 0)
        {
            Debug.Log("gameover");
            deadZone.gameOver();
            _comboCounter = 0;
        }
        if(_comboCounter > 0&& difficulty == 1)
        {
            _comboCounter -= 1f * Time.deltaTime;
            
        }
        if (_comboCounter > 0 && difficulty == 2)
        {
            _comboCounter -= 1.5f * Time.deltaTime;
        }
        if (_comboCounter > 0 && difficulty == 3)
        {
            _comboCounter -= 2f * Time.deltaTime;
        }
        if (_comboCounter > _maxCombo)
        {
            _comboCounter = _maxCombo;
        }
        
        
    }
   
}

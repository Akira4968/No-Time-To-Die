using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]Text Score;
    [SerializeField] Text HighScore;
    [SerializeField] Slider HP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = GameManager.instance.Score().ToString();
        HP.value = PlayerControler.instance.HP * 0.2f;
    }

}

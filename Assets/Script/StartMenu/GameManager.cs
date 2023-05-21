using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float ScorePerSecond = 20;
    float score = 0;
    const float HighScore = 0;
    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene(0);
    }
    public float Score()
    {
        score += ScorePerSecond * Time.deltaTime;
        return score;
    }
    public void EnemyScore()
    {
        score += 300;
    }
    public void GameOver()
    {
        if(Score() > HighScore)
        {
            score = HighScore;
        }
    }
}

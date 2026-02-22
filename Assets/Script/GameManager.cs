using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // ================= Initialize ==================
    [SerializeField] private GameObject PlayMenu;
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private TMP_Text scoreText, bestScoreText;
     
    private int score = 0;
    private int bestScore = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy (gameObject);
            return;
        }
        Instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("HighScore", 0); // Unity tìm trong máy xem có lưu "HighScore" chưa
                                                        // Nếu có → lấy ra
                                                        // Nếu chưa → trả về 0 ❌ Không có nghĩa là Unity lưu số 0.
        SetDefaultMenu();
        UpdateScoreText();
        UpdateBestScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetDefaultMenu()
    {
        PlayMenu.SetActive(true);
        GameOverMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void SetGameOverMenu()
    {

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("HighScore", bestScore);  // set bestScore vào HighScore
            PlayerPrefs.Save(); // đảm bảo lưu ngay
        }   

    UpdateBestScoreText();
        Time.timeScale = 0f;
        PlayMenu.SetActive(false);
        GameOverMenu.SetActive(true);
    }
    public void SetPlayMenu()
    {
        Time.timeScale = 1f;
        PlayMenu.SetActive(false);
        GameOverMenu.SetActive(false);

    }

    // ==================== Score ======================

    public void AddScore(int num)
    {
        score += num;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        scoreText.text = "Score:" + score.ToString();
    }
    private void UpdateBestScoreText()
    {
        bestScoreText.text = "Best:" + bestScore.ToString();
    }

}

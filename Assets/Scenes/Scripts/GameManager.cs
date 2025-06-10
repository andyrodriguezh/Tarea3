using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI bulletsText;
    public TextMeshProUGUI hitsText;
    public TextMeshProUGUI gameOverText;

    [Header("Gameplay")]
    public int maxBullets = 10;

    private int bulletsLeft;
    private int hits;

    void Start()
    {
        bulletsLeft = maxBullets;
        hits = 0;
        UpdateUI();
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);
    }

    public bool TryShoot()
    {
        if (bulletsLeft > 0)
        {
            bulletsLeft--;
            UpdateUI();
            if (bulletsLeft == 0)
            {
                GameOver();
            }
            return true;
        }
        return false;
    }

    public void AddHit()
    {
        hits++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (bulletsText != null)
            bulletsText.text = "Balas: " + bulletsLeft;
        if (hitsText != null)
            hitsText.text = "Aciertos: " + hits;
    }

    void GameOver()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "¡Sin balas!";
        }
        Invoke("RestartGame", 2f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
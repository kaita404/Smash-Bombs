using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static int player1Score = 0;
    public static int player2Score = 0;

    public Text player1ScoreText;
    public Text player2ScoreText;

    public GameObject endGamePanel;
    public Text endGamePlayer1Score;
    public Text endGamePlayer2Score;

    public Image player1Image;
    public Image player2Image;

    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
        {
            player1ScoreText.text = " " + player1Score;
            player2ScoreText.text = " " + player2Score;

            // Check if either player has reached 20 points
            if (player1Score >= 20)
            {
                player1ScoreText.color = Color.red;
            }

            if (player2Score >= 20)
            {
                player2ScoreText.color = Color.red;
            }

            // Check if either player has reached 30 points
            if (player1Score >= 30 || player2Score >= 30)
            {
                EndGame();
            }
        }
        else
        {
            // Stop updating other components in the scene
            DisableOtherObjects();
        }
    }

    void EndGame()
    {
        if (!isGameOver)
        {
            isGameOver = true;

            // Display the UI Panel
            endGamePanel.SetActive(true);

            // Display final scores for players
            endGamePlayer1Score.text = "" + player1Score;
            endGamePlayer2Score.text = "" + player2Score;

            // Hide player names and scores during the final panel
            player1ScoreText.enabled = false;
            player2ScoreText.enabled = false;

            // Hide specific images
            player1Image.enabled = false;
            player2Image.enabled = false;

            // Reactivate other components after a certain time if needed
            // Invoke("EnableOtherObjects", 3f);
        }
    }

    void DisableOtherObjects()
    {
        // Disable other components here
        // For example, disable Renderers or Colliders for other objects
        Renderer[] renderers = FindObjectsOfType<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = false;
        }

        Collider[] colliders = FindObjectsOfType<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
    }
}

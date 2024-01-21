using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    public void HandlePlayerDeath()
    {
        LoadDeathScreen();
    }

    private void LoadDeathScreen()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

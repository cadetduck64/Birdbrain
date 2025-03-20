using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    public void LoadLevel(int level) {
        SceneManager.LoadScene(level);
    }
}




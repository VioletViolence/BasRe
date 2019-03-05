using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public void SceneReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

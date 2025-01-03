using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public void GameQuit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

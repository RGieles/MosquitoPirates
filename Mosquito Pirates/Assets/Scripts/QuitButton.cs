using UnityEngine;
using UnityEngine.UI;

public class QuitButtonScript : MonoBehaviour
{
    void Start()
    {
        // Get the Button component attached to this GameObject and add a listener to it
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnQuitButtonClick);
        }
        else
        {
            Debug.LogError("No Button component found on this GameObject.");
        }
    }

    void OnQuitButtonClick()
    {
        // Quit the application
        Application.Quit();
        // If running in the editor, stop playing
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

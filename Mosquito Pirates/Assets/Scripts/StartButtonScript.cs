using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    // The name of the scene you want to load
    public string sceneToLoad;

    void Start()
    {
        // Get the Button component attached to this GameObject and add a listener to it
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnStartButtonClick);
        }
        else
        {
            Debug.LogError("No Button component found on this GameObject.");
        }
    }

    void OnStartButtonClick()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}

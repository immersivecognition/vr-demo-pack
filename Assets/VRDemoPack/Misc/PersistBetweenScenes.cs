using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PersistBetweenScenes : MonoBehaviour
{
    public string uniqueID;
    public UnityEvent onSceneLoaded;

    // called first
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        onSceneLoaded.Invoke();
    }

    // called when the game is terminated
    void OnDisable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// Called when the script is loaded or a value is changed in the
    /// inspector (Called in the editor only).
    /// </summary>
    void OnValidate()
    {
        if (uniqueID == string.Empty) uniqueID = name;
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        DontDestroyOnLoad(this.gameObject);
        PersistBetweenScenes[] persists = GameObject.FindObjectsOfType<PersistBetweenScenes>();
        foreach (PersistBetweenScenes persist in persists)
        {
            if (persist == this) continue;
            else if (persist.uniqueID != this.uniqueID) continue;
            else
            {
                uniqueID = string.Empty;
                Destroy(this.gameObject);
            }
        }
    }
}

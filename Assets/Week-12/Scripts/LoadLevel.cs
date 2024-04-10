using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] string levelToLoad;

    [ContextMenu("LoadLevel")]
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}

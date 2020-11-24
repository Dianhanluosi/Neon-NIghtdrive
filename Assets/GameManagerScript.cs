using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(this);
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    SceneLoaderScript sceneloader;
    // Start is called before the first frame update
    void Start()
    {
        sceneloader = GetComponent<SceneLoaderScript>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sceneloader.LoadMainScene("StartScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sceneloader.LoadMainScene("MainScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sceneloader.LoadMainScene("EndScene");
        }
    }
}

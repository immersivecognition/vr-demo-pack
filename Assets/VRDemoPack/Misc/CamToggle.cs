using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CamToggle : MonoBehaviour
{

    public KeyCode toggleKey;
    public GameObject cam;
    public UnityEvent onEnable;
    public UnityEvent onDisable;

    // Use this for initialization
    void Awake()
    {
        cam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if (cam.activeSelf)
            {
                onDisable.Invoke();
            }
            else
            {
                onEnable.Invoke();
            }
            cam.SetActive(!cam.activeSelf);
        }
    }
}

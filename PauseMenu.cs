using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 1;
    }
    public void OnEnable()
    {
        //Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        print(Time.timeScale);
        //Time.timeScale = 1;
    }
}

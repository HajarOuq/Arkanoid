using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameover;
    public Text ded;
    void Start()
    {
        ded.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            ded.gameObject.SetActive(true);
        }
    }
}

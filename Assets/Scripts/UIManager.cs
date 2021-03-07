using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text gameOver;
    public Button replay;
    // Start is called before the first frame update
    void Start()
    {
        GameController.instance.uiMaganer = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

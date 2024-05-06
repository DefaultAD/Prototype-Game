using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;
    public Toggle toggle4;
    public Toggle toggle5;

    [SerializeField] private int currentDifficulty;
    private void Awake()
    {
        currentDifficulty = PlayerPrefs.GetInt("Difficulty");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (currentDifficulty == 1)
        {
            toggle1.isOn = true;
        }
        else if (currentDifficulty == 2)
        {
            toggle2.isOn = true;
        }
        else if (currentDifficulty == 3)
        {
            toggle3.isOn = true;
        }
        else if (currentDifficulty == 4)
        {
            toggle4.isOn = true;
        }
        else
        {
            toggle5.isOn = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card Layout", menuName = "Layouts")]
public class CardLayout : ScriptableObject
{
    public string Name;

    public int cardAmount;

    public int cellXSize;
    public int cellYSize;

    public int columns;
}

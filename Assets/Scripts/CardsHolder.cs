using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Custom/CardHolder")]
public class CardsHolder : ScriptableObject
{
    public int amountPairedCards;

    public bool ChooseTypeCards;
}


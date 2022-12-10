using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetCards : MonoBehaviour
{ 
    public CardsHolder cardsHolder;
    private  int _cardsOnScreen = 6;
    [SerializeField] private Sprite _backSprite = null;
    [SerializeField] private List<Sprite> _fruitsSprites = null;
    [SerializeField] private List<Sprite> _numberSprites = null;
    private List<Sprite> sprites = null;
    public bool _isFruits = true;


    private void Start()
    {
        _cardsOnScreen = cardsHolder.amountPairedCards;
    }
    public Sprite GetBackSprite()
    {
        return _backSprite;
    }

    public List<Sprite> GetPlayCardsSprites()
    {
        sprites = _isFruits ? _fruitsSprites : _numberSprites;
        if ( _isFruits == true)
        {
            sprites = _fruitsSprites;
            _isFruits = cardsHolder.ChooseTypeCards;
        }
        else
        {
            sprites = _numberSprites;
            _isFruits = cardsHolder.ChooseTypeCards;

        }
       
        while (_cardsOnScreen > sprites.Count)
        {
            sprites.RemoveAt(Random.Range(0, sprites.Count));
        }
        return sprites;
    }

    public int[] GetCardIndex()
    {
        int[] cardIndex = new int[_cardsOnScreen];
        for (int i =0; i < cardIndex.Length; i++)
        {
            cardIndex[i] = i;
        }
        for (int i = 0; i < cardIndex.Length; i++)
        {
            int temp = cardIndex[i];
            int rnd = Random.Range(0, cardIndex.Length);
            cardIndex[i] = cardIndex[rnd];
            cardIndex[rnd] = temp;
        }
        return cardIndex;
    }
}
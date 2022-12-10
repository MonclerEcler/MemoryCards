using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardsSpawner : MonoBehaviour
{
   [SerializeField] private PresetCards _presetCards = null;
    [SerializeField] private Card _cardPrefub = null;
    [SerializeField] private UnityEvent _startCollect = new UnityEvent();

    private const float LeftPositionX = -5f;
    private const float OffsetX = 2f;
    private float _positionY = 1.5f;
    public static bool FruitsSelected = true;

    private void Start()
    {   
        if (FruitsSelected == true)
        {
            CheckTypeCardsFruits();
        }
        else
        {
            CheckTypeCardsNumber();
        }
       Spawn();
    }

    private void CheckTypeCardsFruits()
    {
        _presetCards._isFruits = true;
    }

    private void CheckTypeCardsNumber()
    {
        _presetCards._isFruits = false;
    }

    public void Spawn()
    {
        Transform localTransfom = GetComponent<Transform>();
        Card card;
        Sprite backSprite = _presetCards.GetBackSprite();
        List<Sprite> playCardsSprites = _presetCards.GetPlayCardsSprites();

        for (int i = 0; i < 2; i++)
        {
            int[] playCardIndex = _presetCards.GetCardIndex();
            float positionX = LeftPositionX;

            for (int j = 0; j < playCardIndex.Length; j++)
            {
                card = Instantiate(_cardPrefub) as Card;
                card.transform.position = new Vector3(positionX, _positionY + localTransfom.position.y);
                card.transform.parent = localTransfom;
                card.SetParameters(backSprite, playCardsSprites[playCardIndex[j]], playCardIndex[j]);
                positionX += OffsetX;
            }
            _positionY *= -1;
        }
         _startCollect?.Invoke();
    }
}

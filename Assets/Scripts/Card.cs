using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Card : MonoBehaviour
{
    private CardCollector _cardCollector;

    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2D;
    private Sprite _frontSprite;
    private Sprite _backSprite;
    private bool _isBackSide = true;

    public int Index { get; private set; }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnMouseDown()
    {
       
        if (_cardCollector.TwoCardsClosed())
        {
            _boxCollider2D.enabled = false;
            CardAnimation();
            _cardCollector.OpenCard(this);
        }
    }

    private void EnableCollider()
    {
        _boxCollider2D.enabled = true;
    }

    public  void CardAnimation()
    {
        if (_isBackSide == true)
        {
            transform.DORotate(new Vector2(0, 180), 1f);
            _spriteRenderer.sprite = _frontSprite;
            _isBackSide = false;
        }
        else
        {
            transform.DORotate(new Vector2(0, 0), 1f);
            _spriteRenderer.sprite = _backSprite;
            _isBackSide = true;
            EnableCollider();
        }
    }

    public void SetParameters(Sprite back, Sprite front, int index)
    {
        _spriteRenderer.sprite = _backSprite = back;
        _frontSprite = front;
        Index = index;
    }

    public void SetCardCollector(CardCollector cardCollector)
    {
        _cardCollector = cardCollector;
    }
}

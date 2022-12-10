using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : MonoBehaviour
{
    public Button numberCardsBtn;
    public Button fruitsCradsBtn;

    void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        numberCardsBtn = root.Q<Button>("btnNamberCards");
        fruitsCradsBtn = root.Q<Button>("btnNumberCards");

        numberCardsBtn.clicked += NumberCardsBtn;
        fruitsCradsBtn.clicked += FruitsCardBtn;
    }

    private void NumberCardsBtn()
    {
        CardsSpawner.FruitsSelected = false;
        SceneManager.LoadScene(1);
    }

    private void FruitsCardBtn()
    {
        CardsSpawner.FruitsSelected = true;
        SceneManager.LoadScene(1);
    }
}

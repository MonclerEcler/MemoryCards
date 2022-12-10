using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ProcessGameBtn : MonoBehaviour
{
    [Header("Back/Restart Button")]
    public Button backBtn;
    public Button restartBtn;


    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        backBtn = root.Q<Button>("backMainMenuBtn");
        restartBtn = root.Q<Button>("restartGameBtn");

        backBtn.clicked += BackBtn;
        restartBtn.clicked += RestartBtn;
    }

    public void BackBtn()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}

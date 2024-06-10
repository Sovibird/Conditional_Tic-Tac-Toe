using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private SceneLoader changer;
    [SerializeField] private ModalWindowPanel modalAnswer;
    [SerializeField] private ModalWindowPanel modalWin;

    public GameView gameView;
    Vector2Int coordinates;
    bool isShown;

    public List<List<Image>> grid;
    public Sprite X;
    public Sprite O;

    private void Awake()
    {
        grid = new();
        for (int x = 0; x < 3; x++)
        {
            grid.Add(new());
            for (int y = 0; y < 3; y++)
            {
                grid[x].Add(null);
            }
        }
    }

    private void Start()
    {
        modalAnswer.gameObject.SetActive(false);
        modalWin.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameView.FinishGame())
        {
            modalWin.gameObject.SetActive(true);
        }
    }

    public void ButtonPlay()
    {
        changer.FadeToLevel(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        changer.FadeToLevel(0);
    }

    public void ShowWindow(Vector2Int coordinates)
    {
        if (isShown) return;
        modalAnswer.gameObject.SetActive(true);
        this.coordinates = coordinates;
        isShown = true;
    }

    public void RegisterButton(Vector2Int coordinates, Image view)
    {
        if (grid[coordinates.x][coordinates.y] != null) Debug.LogError("cell already registered");
        grid[coordinates.x][coordinates.y] = view;
    }

    public void CellButton(Vector2Int coordinates)
    {
        gameView.CellClicked(coordinates);
    }

    public void RecolorTile(Vector2Int coordinates, TileState state)
    {
        if (state == TileState.X)
            grid[coordinates.x][coordinates.y].sprite = X;
        else if (state == TileState.O)
            grid[coordinates.x][coordinates.y].sprite = O;
        else grid[coordinates.x][coordinates.y].sprite = null;
    }

    public void ConfirmButton()
    {
        string answer = modalAnswer.inputField.text;
        int number = Int32.Parse(answer);
        gameView.ConfirmMove(coordinates, number);
        isShown = false;
        modalAnswer.gameObject.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// ゲーム画面
/// ゲーム中に表示するUIです
/// あくまで例として実装してあります
/// ボタンなどは適宜編集してください
/// </summary>
public class GameCanvasManager : BaseCanvasManager
{
    [SerializeField] Text countDownText;
    [SerializeField] Button startButton;
    float timer;

    public override void OnStart()
    {


        base.SetScreenAction(thisScreen: ScreenState.Game);

        gameObject.SetActive(true);
        startButton.onClick.AddListener(OnClickStartButton);

    }

    public override void OnUpdate()
    {
        if (!base.IsThisScreen()) { return; }
        if (Variables.gameState == GameState.CountDown)
        {
            int num = Mathf.CeilToInt(timer);
            countDownText.text = num.ToString("F0");
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Variables.gameState = GameState.Play;
                countDownText.gameObject.SetActive(false);
            }
        }

    }

    protected override void OnOpen()
    {
        gameObject.SetActive(true);
    }

    protected override void OnClose()
    {
        // gameObject.SetActive(false);
    }

    public override void OnInitialize()
    {
        countDownText.gameObject.SetActive(false);
        Variables.gameState = GameState.Start;
    }

    void OnClickStartButton()
    {
        Variables.gameState = GameState.CountDown;
        startButton.gameObject.SetActive(false);
        countDownText.gameObject.SetActive(true);
        timer = 3;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player2DeliverUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI Player2recipesDeliveredText;


    //private void Awake()
    //{
    //playAgainButton.onClick.AddListener(() => {
    //NetworkManager.Singleton.Shutdown();
    //Loader.Load(Loader.Scene.MainMenuScene);
    //});
    //}

    private void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsGameOver())
        {
            Hide();
        }
        else
        {
            Show();
        }
    }
    private void Update()    //即時更新菜單
    {
        Player2recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();
    }
    private void Show()
    {
        gameObject.SetActive(true);
        //playAgainButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }


}


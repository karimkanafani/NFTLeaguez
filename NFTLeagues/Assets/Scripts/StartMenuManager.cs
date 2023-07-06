using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solana.Unity.SDK;
using UnityEngine;
using UnityEngine.UI;
using Solana.Unity.Wallet;
using TMPro;


public class StartMenuManager : MonoBehaviour
{
    // Game Objects
    public GameObject ConnectedState;
    public GameObject DisonnectedState;
    public GameObject MainScreen;
    public GameObject PlayScreen;
    public GameObject RosterScreen;
    public GameObject LeaderboardScreen;
    public GameObject ThreeOnThreeScreen;
    public Button MainButton;
    public Button PlayButton;
    public Button RosterButton;
    public Button LeaderboardButton;
    public Button loginPhantomWalletButton;
    public Button logoutButton;
    public TextMeshProUGUI walletKey;

    private void Start()
    {
        // Initial State
        ConnectedState.SetActive(false);
        DisonnectedState.SetActive(true);
        GoToMain();
        
        // Add button listeners
        loginPhantomWalletButton.onClick.AddListener(LoginCheckerWalletAdapter);
        MainButton.onClick.AddListener(GoToMain);
        PlayButton.onClick.AddListener(GoToPlay);
        RosterButton.onClick.AddListener(GoToRoster);
        LeaderboardButton.onClick.AddListener(GoToLeaderboard);
        logoutButton.onClick.AddListener(LogoutWallet);

        
        // Check if we are in Unity Editor
        if (Application.platform is RuntimePlatform.LinuxEditor or RuntimePlatform.WindowsEditor or RuntimePlatform.OSXEditor)
        {
            loginPhantomWalletButton.onClick.RemoveListener(LoginCheckerWalletAdapter);
            loginPhantomWalletButton.onClick.AddListener(() =>
                Debug.LogWarning("Wallet adapter login is not yet supported in the editor"));
        }

    }
    

    private async void LoginCheckerWalletAdapter()
    {
        
        if(Web3.Instance == null) return;
        var account = await Web3.Instance.LoginWalletAdapter();
        CheckAccount(account);
        print("Login");
    }
    
    private void CheckAccount(Account account)
    {
        if (account != null)
        {
            ConnectedState.SetActive(true);
            DisonnectedState.SetActive(false);
            String showcaseKey = account.PublicKey.ToString().Substring(0, 4) + "..." + account.PublicKey.ToString().Substring(account.PublicKey.ToString().Length - 4);
            walletKey.text = showcaseKey;
        }
        else
        {
            print("Invalid acc");
        }
    }
    
    private async void LogoutWallet()
    {
        print("Logout");
        Web3.Instance.Logout();
        ConnectedState.SetActive(false);
        DisonnectedState.SetActive(true);
    }

    // Go to main screen
    private void GoToMain()
    {
        print("Going Main");
        MainScreen.SetActive(true);
        PlayScreen.SetActive(false);
        RosterScreen.SetActive(false);
        LeaderboardScreen.SetActive(false);
        ThreeOnThreeScreen.SetActive(false);
    }
    
    // Go to Play screen
    private void GoToPlay()
    {
        print("Going Play");
        MainScreen.SetActive(false);
        PlayScreen.SetActive(true);
        RosterScreen.SetActive(false);
        LeaderboardScreen.SetActive(false);
        ThreeOnThreeScreen.SetActive(false);
    }
    
    // Go to Roster screen
    private void GoToRoster()
    {
        print("Going Roster");
        MainScreen.SetActive(false);
        PlayScreen.SetActive(false);
        RosterScreen.SetActive(true);
        LeaderboardScreen.SetActive(false);
        ThreeOnThreeScreen.SetActive(false);
    }
    
    // Go to Leaderboard Screen
    private void GoToLeaderboard()
    {
        print("Going LB");
        MainScreen.SetActive(false);
        PlayScreen.SetActive(false);
        RosterScreen.SetActive(false);
        LeaderboardScreen.SetActive(true);
        ThreeOnThreeScreen.SetActive(false);
    }

    public void openMarketplace()
    {
        Application.OpenURL("https://magiceden.io/marketplace/nft_leaguez");
    }
    
    public void openCommunity()
    {
        Application.OpenURL("https://discord.com/invite/njuwrF84bF");
    }
    
    public void openSupport()
    {
        Application.OpenURL("https://start.nftleaguez.com");
    }
}

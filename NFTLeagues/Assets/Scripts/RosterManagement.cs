using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Solana.Unity.SDK;
using Solana.Unity.SDK.Nft;
using UnityEngine;
using UnityEngine.UI;
using Solana.Unity.Wallet;
using TMPro;

public class RosterManagement : MonoBehaviour
{
    [SerializeField] 
    private Transform scrollViewContent;

    [SerializeField] 
    private GameObject prefab;

    private List<Nft> NFTsOwned = new List<Nft>();

    private int totalNFTs;

    private bool isLoaded= true;

    private List<GameObject> LoadedNFTPics = new List<GameObject>();

    // Start is called before the first frame update
    private async void OnEnable()
    {
        Debug.Log("LOAD NFTS");
        Web3.OnNFTsUpdate += OnNFTsUpdated;
        // Check if we are in Unity Editor
        if (Application.platform is RuntimePlatform.LinuxEditor or RuntimePlatform.WindowsEditor or RuntimePlatform.OSXEditor)
        {
            if (LoadedNFTPics.Count == 0)
            {
                var nft = await Nft.TryGetNftData("JTaR8YYjC8haBsxj5t9s9iVLxiEuA61YSSpiWUpHWfp", Web3.Rpc, true, 1024);
                var nft1= await Nft.TryGetNftData("eafa782LsZFUh6HoVwNDYMSMRh6nuA4U9UjjygavqNG", Web3.Rpc, true, 1024);
                var nft2 = await Nft.TryGetNftData("4ZrN4FuKhfbaRB4APuoCPYMQRTBvVWC1ogb4f71GG9qS", Web3.Rpc, true, 1024);
                List<Nft> tmpList = new List<Nft>();
                tmpList.Add(nft);
                tmpList.Add(nft1);
                tmpList.Add(nft2);
                NFTsOwned = tmpList;
                LoadNFTsOnScreen();
            }
        }
    }

    private void OnDisable()
    {
        Debug.Log("UNLOAD NFTS");
        Web3.OnNFTsUpdate -= OnNFTsUpdated;
        foreach (GameObject pic in LoadedNFTPics)
        {
            Destroy(pic);
        }
        LoadedNFTPics.Clear();
        print("Number of loaded" + LoadedNFTPics.Count);
    }

    private void OnNFTsUpdated(List<Nft> nfts, int total)
    {
        Debug.Log($"NFTs updated {nfts.Count}/{total}");
        NFTsOwned = nfts;
        print("Number of loaded " + LoadedNFTPics.Count + " Number of total " + total);
        if (nfts.Count == total)
        {
            if (isLoaded == false)
            {
                isLoaded = true;
                LoadNFTsOnScreen();
            }
            else
            {
                isLoaded = false;
            }
        }
    }

    private void LoadNFTsOnScreen()
    {
        print("CALLED HELPER");
        foreach (Nft NFT in NFTsOwned)
        {
            if (NFT.metaplexData.data.metadata.symbol.Equals("LGZ"))
            {
                GameObject newNFT = Instantiate(prefab, scrollViewContent);
                if(newNFT.TryGetComponent<ScrollViewItem>(out ScrollViewItem item))
                {
                    item.ChangeImage(NFT.metaplexData.nftImage.file);
                }
                LoadedNFTPics.Add(newNFT);
                totalNFTs++;
            }
        }
    }
}

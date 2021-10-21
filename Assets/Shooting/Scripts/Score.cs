using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Score : MonoBehaviourPunCallbacks
{
    int score;
    [SerializeField] private Text scoreText;

    ExitGames.Client.Photon.Hashtable hashtable;

    // Start is called before the first frame update
    void Start()
    {      
        hashtable.Add("Score", 0);
        hashtable.Add(1.0f, "hello");

        PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable);
    }


    public void AddScore() {
        hashtable["Score"] = score + 1;
        PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable);
    }


    
    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        score = (PhotonNetwork.CurrentRoom.CustomProperties["Score"] is int value) ? value : 0;
        scoreText.text = score.ToString();
    }
}

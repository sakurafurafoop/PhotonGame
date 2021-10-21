using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

namespace NumberGame {
    public class DisplayNumber : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Text playerText, partnerText;
        private Dictionary<int, int> numberDictionary = new Dictionary<int, int>();

        private Player[] players;

        private void Awake()
        {
            players = PhotonNetwork.PlayerList;

            for (int i = 0; i < players.Length; i++)
            {
                RegisterDictionary(players[i]);
            }
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            players = PhotonNetwork.PlayerList;
            RegisterDictionary(newPlayer);
        }

        private void RegisterDictionary(Player player)
        {
            numberDictionary.Add(player.ActorNumber, 0);
        }


        [PunRPC]
        public void UpdateDictionary(int num)
        {
            numberDictionary[PhotonNetwork.LocalPlayer.ActorNumber] = num;
            DisplayText();
        }

        private void DisplayText()
        {
            playerText.text = numberDictionary[PhotonNetwork.LocalPlayer.ActorNumber].ToString();
            partnerText.text = numberDictionary[PhotonNetwork.PlayerListOthers[0].ActorNumber].ToString();
        }
    }

}


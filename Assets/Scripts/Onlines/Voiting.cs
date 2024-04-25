using Photon.Pun;
using TMPro;
using UnityEngine;

public class Voiting : MonoBehaviourPun
{
   [SerializeField] private TextMeshProUGUI _countVotedText;
   [SerializeField] private int _countVoted;

   public void Vote()
   {
      photonView.RPC("ProcessingVote",RpcTarget.AllBuffered);
   }

   [PunRPC]
   void ProcessingVote()
   {
      _countVoted++;
      _countVotedText.text = _countVoted.ToString();
   }
}

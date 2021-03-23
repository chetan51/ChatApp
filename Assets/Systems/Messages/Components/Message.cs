using ChatApp.Data;
using TMPro;
using UnityEngine;

namespace ChatApp.Messages {

    public class Message : Behavior {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI bodyText;
        
        public void Initialize(MessageData messageData, PersonData personData)
        {
            nameText.text = string.Format("{0} {1}", personData.firstName, personData.lastName);
            timeText.text = messageData.time;
            bodyText.text = messageData.body;
        }
    }

}
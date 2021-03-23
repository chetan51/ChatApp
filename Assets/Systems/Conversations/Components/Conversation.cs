using ChatApp.Data;
using TMPro;
using UnityEngine;

namespace ChatApp.Conversations {

    public class Conversation : Behavior
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI lastMessageTimeText;

        public void Initialize(ConversationData data)
        {
            nameText.text = string.Format("{0} {1}", data.person.firstName, data.person.lastName);
            lastMessageTimeText.text = data.lastMessageTime;
        }

        public void OnConversationPressed()
        {
            Debug.Log("TODO: conversation pressed");
        }

        public void OnPhotoPressed()
        {
            Debug.Log("TODO: photo pressed");
        }
    }

}
using ChatApp.Data;
using ChatApp.Messages;
using ChatApp.Navigation;
using TMPro;
using UnityEngine;

namespace ChatApp.Conversations {

    public class Conversation : Behavior
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI lastMessageTimeText;
        [SerializeField] private MessageList messageListPrefab;

        private ConversationData conversationData;

        public void Initialize(ConversationData data)
        {
            conversationData = data;

            if (data.persons.Count == 0)
            {
                Debug.LogError("Invalid conversation; not enough persons found.");
                return;
            }
            
            // show info for first person in conversation
            // (by convention, the first person is the main other person in the conversation)
            PersonData mainPerson = data.persons[0];
            nameText.text = string.Format("{0} {1}", mainPerson.firstName, mainPerson.lastName);
            lastMessageTimeText.text = data.lastMessageTime;
        }

        public void OnConversationPressed()
        {
            MessageList messageList = Instantiate(messageListPrefab);
            messageList.Initialize(conversationData.id);
            NavigationView navigationView = NavigationManager.Instance.SpawnAndPush("Messages");
            navigationView.AddToContent(messageList.gameObject);
        }

        public void OnPhotoPressed()
        {
            Debug.Log("TODO: photo pressed");
        }
    }

}
using ChatApp.Data;
using ChatApp.Messages;
using ChatApp.Navigation;
using ChatApp.Profiles;
using TMPro;
using UnityEngine;

namespace ChatApp.Conversations {

    public class Conversation : Behavior
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI lastMessageTimeText;
        [SerializeField] private MessageList messageListPrefab;
        [SerializeField] private Profile profilePrefab;

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
            if (conversationData.persons.Count == 0) {
                Debug.LogError("Couldn't open profile; invalid number of persons in conversation");
                return;
            }
            
            PersonData mainPerson = conversationData.persons[0];
            Profile profile = Instantiate(profilePrefab);
            profile.Initialize(mainPerson);
            NavigationView navigationView = NavigationManager.Instance.SpawnAndPush("Profile");
            navigationView.AddToContent(profile.gameObject);
        }
    }

}
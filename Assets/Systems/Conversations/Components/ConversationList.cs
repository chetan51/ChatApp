using ChatApp.Data;
using UnityEngine;

namespace ChatApp.Conversations {

    public class ConversationList : Behavior
    {
        [SerializeField] private GameObject content;
        [SerializeField] private Conversation conversationPrefab;

        public void Initialize(ConversationsData data)
        {
            foreach (ConversationData conversationData in data.conversations)
            {
                Conversation conversation = Instantiate(conversationPrefab, content.transform);
                conversation.Initialize(conversationData);
            }
        }

        private void Start()
        {
            // TODO: move to a StartupManager/NavigationManager that creates a new ConversationsNavigationView
            LoadData();
        }

        private void LoadData()
        {
            ConversationsData data = DataManager.Instance.GetConversations();
            Initialize(data);
        }
    }

}
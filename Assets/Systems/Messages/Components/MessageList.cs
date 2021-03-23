using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using ChatApp.Data;
using UnityEngine.UI;

namespace ChatApp.Messages {

    public class MessageList : Behavior
    {
        private static int numConversationsPerPage = 25;
            
        [SerializeField] private GameObject content;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Message messagePrefab;

        private string conversationId;
        private PersonData personData;

        private int startIndex = 0;
        
        public void Initialize(string conversationId)
        {
            this.conversationId = conversationId;

            LoadPerson();
            LoadMessages();
        }

        public void OnShowMorePressed()
        {
            LoadMessages();
        }

        private void LoadPerson()
        {
            personData = DataManager.Instance.GetPersonForConversationWithId(conversationId);

            if (personData == null)
            {
                Debug.LogError(string.Format("Couldn't load person for conversation {0}", conversationId));
            }
        }

        private void LoadMessages()
        {
            List<MessageData> messages = DataManager.Instance.GetMessagesForConversationWithId(conversationId, startIndex, numConversationsPerPage);

            if (messages == null)
            {
                Debug.LogError(string.Format("Couldn't load messages for conversation {0}", conversationId));
                return;
            }
            
            startIndex += numConversationsPerPage;
            AddMessages(messages);
        }

        private void AddMessages(List<MessageData> messages)
        {
            foreach (MessageData messageData in messages)
            {
                Message message = Instantiate(messagePrefab, content.transform);
                message.Initialize(messageData, personData);
            }
            
            // rebuild layout to update nested content size fitters
            // TODO: remove the need for this
            RebuildLayout();
        }

        private async void RebuildLayout()
        {
            // rebuild layout to update nested content size fitters
            // (waiting for a frame for each level of nesting)
            await Task.Yield();
            LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
            await Task.Yield();
            LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
            await Task.Yield();
            LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
        }
    }

}
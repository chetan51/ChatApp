using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using ChatApp.Data;
using UnityEngine.UI;

namespace ChatApp.Messages {

    public class MessageList : Behavior
    {
        private static int numConversationsPerPage = 40;
            
        [SerializeField] private GameObject content;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Message messagePrefab;
        [SerializeField] private GameObject showMoreObj;

        private string conversationId;
        private List<PersonData> personsData;

        private int startIndex = 0;
        
        public void Initialize(string conversationId)
        {
            this.conversationId = conversationId;
            
            LoadInitialData();
        }

        public void OnShowMorePressed()
        {
            LoadMessages();
        }

        private void LoadInitialData()
        {
            LoadPersons();
            LoadMessages();
        }

        private void LoadPersons()
        {
            personsData = DataManager.Instance.GetPersonsForConversationWithId(conversationId);

            if (personsData == null)
            {
                Debug.LogError(string.Format("Couldn't load persons for conversation {0}", conversationId));
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
            
            // hide show more button if there are no more messages to load
            if (messages.Count < numConversationsPerPage)
            {
                showMoreObj.SetActive(false);
            }
            
            startIndex += numConversationsPerPage;
            AddMessages(messages);
        }

        private void AddMessages(List<MessageData> messages)
        {
            foreach (MessageData messageData in messages)
            {
                Message message = Instantiate(messagePrefab, content.transform);
                message.Initialize(messageData, personsData[messageData.personIndex]);
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
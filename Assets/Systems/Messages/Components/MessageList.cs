using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using ChatApp.Data;
using UnityEngine.UI;

namespace ChatApp.Messages {

    public class MessageList : Behavior {
        [SerializeField] private GameObject content;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Message messagePrefab;

        private PersonData personData;
        
        public void Initialize(List<MessageData> messages, PersonData personData)
        {
            this.personData = personData;
            
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
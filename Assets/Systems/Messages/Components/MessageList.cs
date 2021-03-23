using System.Collections.Generic;
using UnityEngine;
using ChatApp.Data;

namespace ChatApp.Messages {

    public class MessageList : Behavior {
        [SerializeField] private GameObject content;
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
        }
    }

}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChatApp.Data {

    public class DataManager : Singleton<DataManager>
    {
        public const string pathToData = "sample_data";

        private ConversationsData conversationsData;

        public ConversationsData GetConversations()
        {
            return conversationsData;
        }

        public List<MessageData> GetMessagesForConversationWithId(string conversationId, int start = 0, int count = 25)
        {
            ConversationData conversation = conversationsData.conversations.Find(c => c.id == conversationId);
            
            if (conversation == null)
            {
                return null;
            }

            return conversation.messages.GetRange(start, count);
        }

        public PersonData GetPersonForConversationWithId(string conversationId)
        {
            ConversationData conversation = conversationsData.conversations.Find(c => c.id == conversationId);
            
            if (conversation == null)
            {
                return null;
            }

            return conversation.person;
        }

        protected override void Awake()
        {
            base.Awake();

            LoadData();
        }

        private void LoadData()
        {
            TextAsset dataAsset = Resources.Load<TextAsset>(pathToData);
            conversationsData = JsonUtility.FromJson<ConversationsData>(dataAsset.text);
        }
    }

    [Serializable]
    public class MessageData
    {
        public string body;
        public string time;
    }

    [Serializable]
    public class PersonData
    {
        public string firstName;
        public string lastName;
        public string pictureURL;
    }

    [Serializable]
    public class ConversationData
    {
        public string id;
        public PersonData person;
        public string lastMessageTime;
        public List<MessageData> messages;
    }

    [Serializable]
    public class ConversationsData
    {
        public List<ConversationData> conversations;
    }

}
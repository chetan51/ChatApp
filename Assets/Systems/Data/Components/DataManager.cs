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

            // make sure count doesn't exceed the remaining number of messages
            int end = Mathf.Min(start + count, conversation.messages.Count);
            if (start + count > end)
            {
                count = Mathf.Max(end - start, 0);
            }
            if (count == 0)
            {
                return new List<MessageData>();
            }

            // NOTE: messages are fetched from backend in reverse chronological order
            return conversation.messages.GetRange(start, count);
        }

        public List<PersonData> GetPersonsForConversationWithId(string conversationId)
        {
            ConversationData conversation = conversationsData.conversations.Find(c => c.id == conversationId);
            
            if (conversation == null)
            {
                return null;
            }

            return conversation.persons;
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
        public int personIndex;
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
        public List<PersonData> persons;
        public string lastMessageTime;
        public List<MessageData> messages;
    }

    [Serializable]
    public class ConversationsData
    {
        public List<ConversationData> conversations;
    }

}
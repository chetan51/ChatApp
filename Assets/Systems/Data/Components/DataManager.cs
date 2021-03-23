using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChatApp.Data {

    public class DataManager : Singleton<DataManager>
    {
        public const string pathToData = "sample_data";
            
        // TODO: make private
        public ConversationsData conversationsData;

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
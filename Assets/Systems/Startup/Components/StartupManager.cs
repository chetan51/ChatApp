using ChatApp.Navigation;
using UnityEngine;
using ChatApp.Conversations;

namespace ChatApp.Startup {

    public class StartupManager : Singleton<StartupManager>
    {
        [SerializeField] private ConversationList conversationListPrefab;
        
        private void Start()
        {
            NavigationView view = NavigationManager.Instance.SpawnAndPush("Conversations", hasBackButton:false);
            ConversationList conversationList = Instantiate(conversationListPrefab);
            view.AddToContent(conversationList.gameObject);
        }
    }

}
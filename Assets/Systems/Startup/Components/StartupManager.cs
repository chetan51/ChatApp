using ChatApp.Navigation;
using UnityEngine;

namespace ChatApp.Startup {

    public class StartupManager : Singleton<StartupManager>
    {
        [SerializeField] private Conversations.Conversations conversationsPrefab;
        
        private void Start()
        {
            NavigationView view = NavigationManager.Instance.SpawnAndPush("Conversations", hasBackButton:false);
            Conversations.Conversations conversations = Instantiate(conversationsPrefab);
            view.AddToContent(conversations.gameObject);
        }
    }

}
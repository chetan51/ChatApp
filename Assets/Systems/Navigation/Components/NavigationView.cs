using TMPro;
using UnityEngine;

namespace ChatApp.Navigation {

    public class NavigationView : Behavior
    {
        [SerializeField] private GameObject content;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private GameObject backButtonObject;

        public string Title
        {
            get => titleText.text;
            set => titleText.text = value;
        }

        public bool HasBackButton
        {
            get => backButtonObject.activeSelf;
            set => backButtonObject.SetActive(value);
        }

        public void AddToContent(GameObject obj)
        {
            obj.transform.SetParent(content.transform, false);
        }
        
        public void OnBackPressed()
        {
            NavigationManager.Instance.Pop();
        }
    }

}
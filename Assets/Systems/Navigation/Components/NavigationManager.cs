using System.Collections.Generic;
using UnityEngine;

namespace ChatApp.Navigation {

    public class NavigationManager : Singleton<NavigationManager>
    {
        [SerializeField] private NavigationView navigationViewPrefab;
        
        private Stack<NavigationView> navigationViews = new Stack<NavigationView>();

        public NavigationView SpawnAndPush(string title, bool hasBackButton = true)
        {
            NavigationView view = Instantiate(navigationViewPrefab, transform);
            view.Title = title;
            view.HasBackButton = hasBackButton;
            
            Push(view);
            return view;
        }

        public void Push(NavigationView view)
        {
            transform.SetParent(view.transform, false);
            navigationViews.Push(view);
        }
        
        public void Pop()
        {
            if (navigationViews.Count == 0) return;

            NavigationView view = navigationViews.Pop();
            Destroy(view);
        }
    }

}
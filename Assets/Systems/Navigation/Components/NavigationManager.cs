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
            // hide top view
            if (navigationViews.Count > 0)
            {
                navigationViews.Peek().gameObject.SetActive(false);
            }
            
            // push new view to top
            transform.SetParent(view.transform, false);
            navigationViews.Push(view);
        }
        
        public void Pop()
        {
            if (navigationViews.Count == 0) return;

            // remove top view
            NavigationView view = navigationViews.Pop();
            Destroy(view.gameObject);
            
            // show current top view
            if (navigationViews.Count > 0)
            {
                navigationViews.Peek().gameObject.SetActive(true);
            }
        }
    }

}
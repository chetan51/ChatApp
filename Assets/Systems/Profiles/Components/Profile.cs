using ChatApp.Data;
using TMPro;
using UnityEngine;

namespace ChatApp.Profiles {

    public class Profile : Behavior {
        [SerializeField] private TextMeshProUGUI nameText;
        
        public void Initialize(PersonData data)
        {
            nameText.text = string.Format("{0} {1}", data.firstName, data.lastName);
        }
    }

}
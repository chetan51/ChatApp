using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Behavior : MonoBehaviour {
    #region Logging
    protected void DebugLog(params object[] text) {
        Debug.Log($"[{GetType().Name}] {string.Join(" ", text)}");
    }

    protected void DebugLogError(params object[] text) {
        Debug.LogError($"[{GetType().Name}] {string.Join(" ", text)}");
    }
    #endregion

    #region MonoBehaviour
    protected virtual void OnValidate() {
        GetComponentOnValidate();
    }
    #endregion

    #region GetComponent
    void GetComponentOnValidate() {
        IEnumerable<FieldInfo> fieldsToGet = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
            .Where(f => f.FieldType.IsSubclassOf(typeof(Component)))
            .Where(f => Attribute.IsDefined(f, typeof(GetComponentOnValidate)));

        foreach (FieldInfo field in fieldsToGet) {
            if (field.IsPrivate && !Attribute.IsDefined(field, typeof(SerializeField))) continue;
            if (field.GetValue(this) != null) continue;
            field.SetValue(this, this.GetComponent(field.FieldType));
        }
    }
    #endregion
}

class GetComponentOnValidate : Attribute {
    public GetComponentOnValidate() { }
}
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ComponentSwapTest : MonoBehaviour
{
    public GameObject to;
    public GameObject fro;

    void Awake()
    {
        Component[] components = fro.GetComponents(typeof(Component));

        foreach (Component component in components)
        {
            if(component.GetType() != typeof(Transform))
            {
                Debug.Log(component.GetType());

                Component newComponent = to.AddComponent(component.GetType());

                BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance;

                PropertyInfo[] froInfo = component.GetType().GetProperties(flags);
                List<object> values = new();
                foreach (PropertyInfo info in froInfo)
                {
                    values.Add(info.GetValue(component));
                    Debug.Log(info.Name);
                }

                PropertyInfo[] toInfo = newComponent.GetType().GetProperties(flags);
                int valueIndx = 0;
                foreach (PropertyInfo info in toInfo)
                {
                    if(info.CanWrite)
                    {
                        info.SetValue(newComponent,values[valueIndx]);
                    }
                    valueIndx++;
                }
            }
        }

        to.tag = fro.tag;
        to.layer = fro.layer;
    }
}
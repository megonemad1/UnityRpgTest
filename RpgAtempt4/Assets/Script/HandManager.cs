using UnityEngine;
using System.Collections;
using UnityEditor;

public class HandManager : MonoBehaviour
{
    public Transform handPosition;
    InventoryManager inv;

    // Use this for initialization
    void Start()
    {
        inv = GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Item CurrentItem = inv.GetSelected();

        if (CurrentItem)
            CurrentItem.setVisible(false);
        foreach (Collider c in CurrentItem.GetComponents<Collider>())
        {
            c.enabled = false;
        }



    }


}
[CustomEditor(typeof(HandManager))]
public class HandEditor : Editor
{


    HandManager m_Instance;
    PropertyField[] m_fields;


    public void OnEnable()
    {
        m_Instance = target as HandManager;
        m_fields = ExposeProperties.GetProperties(m_Instance);
    }

    public override void OnInspectorGUI()
    {

        if (m_Instance == null)
            return;

        this.DrawDefaultInspector();

        ExposeProperties.Expose(m_fields);

    }
}
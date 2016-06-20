//using UnityEngine;
//using System.Collections;
//using UnityEditor;

//public class HandManager : MonoBehaviour
//{
//    public Transform handPosition;
//    InventoryManagerold inv;

//    // Use this for initialization
//    void Start()
//    {
//        inv = GetComponent<InventoryManagerold>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        oldItem CurrentItem = inv.GetSelected();

//        if (CurrentItem)
//            CurrentItem.setVisible(false);
//        Collider[] coliders = CurrentItem.GetComponents<Collider>();
//        if (coliders != null)
//            foreach (Collider c in coliders)
//            {
//                c.enabled = false;
//            }



//    }


//}
//[CustomEditor(typeof(HandManager))]
//public class HandEditor : Editor
//{


//    HandManager m_Instance;
//    PropertyField[] m_fields;


//    public void OnEnable()
//    {
//        m_Instance = target as HandManager;
//        m_fields = ExposeProperties.GetProperties(m_Instance);
//    }

//    public override void OnInspectorGUI()
//    {

//        if (m_Instance == null)
//            return;

//        this.DrawDefaultInspector();

//        ExposeProperties.Expose(m_fields);

//    }
//}
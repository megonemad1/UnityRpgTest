using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ToolTipManager : MonoBehaviour
{
    private Item item;
    private string data;
    public GameObject tooltip;
    public Color titleColor;
    public Color DescriptionColor;

    public void Activate(Item item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }
    public void Deactivate()
    {
        tooltip.SetActive(false);
    }
    public void ConstructDataString()
    {
        data = "<color={0}><b>" + item.title + "</b></color> \n\n <color={1}>" + item.discription + "</color>";

        data = string.Format(data, colorToHex(titleColor), colorToHex(DescriptionColor));
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
    private string colorToHex(Color color)
    {

        return string.Format("#{0:X2}{1:X2}{2:X2}", toByte(color.r), toByte(color.g), toByte(color.b));
    }
    private byte toByte(float f)
    {
        f = Mathf.Clamp01(f);
        return (byte)(f * 255);
    }
    // Use this for initialization
    void Start()
    {
        Deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        if (tooltip.activeSelf)
            tooltip.transform.position = Input.mousePosition; // Vector2.Lerp(tooltip.transform.position, Input.mousePosition, 0.5f);
    }
}

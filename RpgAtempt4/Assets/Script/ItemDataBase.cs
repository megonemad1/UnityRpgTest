using UnityEngine;
using System.Collections.Generic;
using LitJson;
using System.IO;
public class ItemDataBase : MonoBehaviour
{
    private Dictionary<string, Item> ItemDatabase = new Dictionary<string, Item>();
    JsonData itemData;
    void Start()
    {
        string filePath = Application.dataPath + "/StreamingAssets/Items.json";
        if (File.Exists(filePath))
            itemData = JsonMapper.ToObject(File.ReadAllText(filePath));
        else
        {
            Debug.LogError("NoJasonFile in system: " + filePath);
            return;
        }
    }
    public Item getItemByID(string id)
    {
        Item ritem;
        if (!ItemDatabase.TryGetValue(id, out ritem))
            Debug.LogError("id: " + id + " not found");
        return ritem;
    }
    void ConstructItemDataBase()
    {
        if (itemData == null)
        {
            Debug.LogError("ItemData Null, ItemDataBaseNotLoaded");
            return;
        }
        foreach (JsonData item in itemData)
        {
            Item tempItem = new Item(item);
            ItemDatabase.Add(tempItem.id, tempItem);
        }
    }
}
public class Item
{

    public string id { get; set; }
    public string title { get; set; }
    public string discription { get; set; }
    public int value { get; set; }
    public bool stackable { get; set; }
    public int rarity { get; set; }
    public string[] types { get; set; }
    public float damage { get; set; }
    public float armorclass { get; set; }
    public float strength { get; set; }
    public float constitution { get; set; }
    public float dexterity { get; set; }
    public float intelligence { get; set; }
    public float wisdom { get; set; }
    public float charisma { get; set; }
    public Sprite sprite { get; set; }
    public Item()
    {
        id = "";
    }

    public Item(JsonData itemData)
    {
        try
        {
            this.id = itemData["id"].ToString();
            this.title = itemData["title"].ToString();
            this.discription = itemData["discription"].ToString();

            this.value = (int)itemData["value"];
            this.rarity = (int)itemData["rarity"];

            this.stackable = (bool)itemData["stackable"];

            this.types = new string[itemData["types"].Count];
            for (int i = 0; i < this.types.Length; i++)
                this.types[i] = itemData["types"][i].ToString();

            this.damage = (float)itemData["stats"]["damage"];
            this.armorclass = (float)itemData["stats"]["armorclass"];
            this.strength = (float)itemData["stats"]["strength"];
            this.constitution = (float)itemData["stats"]["constitution"];
            this.dexterity = (float)itemData["stats"]["dexterity"];
            this.intelligence = (float)itemData["stats"]["intelligence"];
            this.wisdom = (float)itemData["stats"]["wisdom"];
            this.charisma = (float)itemData["stats"]["charisma"];
            //this.sprite= 
        }
        catch
        {
            this.discription += "\n" + this.id + ": err on load";
            this.id = "";
        }
    }
}

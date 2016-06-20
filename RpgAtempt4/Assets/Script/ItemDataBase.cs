using UnityEngine;
using System.Collections.Generic;
using LitJson;
using System.IO;
using System;

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
        ConstructItemDataBase();
        Debug.Log(ItemDatabase.Count);
        foreach (string s in ItemDatabase.Keys)
            Debug.Log(s);
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

        for (int i = 0; i < itemData.Count; i++)
        {
            Item tempItem = new Item(itemData[i]);
            Debug.Log(tempItem);
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
    public double damage { get; set; }
    public double armorclass { get; set; }
    public double strength { get; set; }
    public double constitution { get; set; }
    public double dexterity { get; set; }
    public double intelligence { get; set; }
    public double wisdom { get; set; }
    public double charisma { get; set; }
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

            this.damage = (double)itemData["stats"]["damage"];
            this.armorclass = (double)itemData["stats"]["armorclass"];
            this.strength = (double)itemData["stats"]["strength"];
            this.constitution = (double)itemData["stats"]["constitution"];
            this.dexterity = (double)itemData["stats"]["dexterity"];
            this.intelligence = (double)itemData["stats"]["intelligence"];
            this.wisdom = (double)itemData["stats"]["wisdom"];
            this.charisma = (double)itemData["stats"]["charisma"];
            this.sprite = Resources.Load<Sprite>("Sprites/Items/" + id);
        }
        catch (Exception e)
        {
            this.discription += "\n" + this.id + ": err on load";
            this.id = "";
            throw e;
        }
    }

    public override string ToString()
    {

        return string.Format("id: {0}, title: {1}, discription: {2}, value: {3}, stackable: {4}, rarity: {5}, types: {6}, damage: {7}, armorclass: {8}, strength: {9}, constitution: {10}, dexterity: {11}, intelligence: {12}, wisdom: {13}, charisma: {14}, sprite: {15}",
            id, title, discription, value, stackable, rarity, "["+string.Join(",", types, 0, types.Length)+"]", damage, armorclass, strength, constitution, dexterity, intelligence, wisdom, charisma, sprite);
    }

}

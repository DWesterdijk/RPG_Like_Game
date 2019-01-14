using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item_Attributes {
    public enum ItemType { Weapon, Armour, Necklace, Trinket};
    public enum ItemRarity { common, uncommon, rare, epic, legendary, demonic, heavenly}
    public ItemType itemType;
    public ItemRarity itemRarity;
    public string itemName, tooltip;
    public long itemDamage, itemDefence, itemMana, itemHealth, itemIntelligence, itemStrength, itemAgility, itemLuck;
    public int itemPrice, itemID;
    public Texture2D itemIco;

    public Item_Attributes(string name, string tt, int id, long damage, long defence, long mana, long health, long intelligence, long str, long agi, long luck, ItemType type, ItemRarity rarity)
    {
        itemName = name;
        tooltip = tt;
        itemID = id;
        itemDamage = damage;
        itemDefence = defence;
        itemMana = mana;
        itemHealth = health;
        itemIntelligence = intelligence;
        itemStrength = str;
        itemAgility = agi;
        itemLuck = luck;
        itemType = type;
        itemRarity = rarity;
        itemIco = Resources.Load<Texture2D>("ItemIco/" + itemType.ToString() + "s/" + name);
    }

    public Item_Attributes()
    {
        itemID = -1;
    }

    public string ItemStats()
    {
        switch (itemType)
        {
            case (ItemType.Weapon):
                return RarityColour(itemRarity) + itemName + "\n" + tooltip + "\n" + "Damage: " +  itemDamage + "\n" + "Rarity: " + itemRarity + "</color>";
            case (ItemType.Armour):
                return RarityColour(itemRarity) + itemName + "\n" + tooltip + "\n" + "Defence: " + itemDefence + "\n" + "Rarity: " + itemRarity + "</color>";
            case (ItemType.Necklace):
                return RarityColour(itemRarity) + itemName + "\n" + tooltip + "\n" + "Health: " + itemHealth + "\n" + "Mana: " + itemMana + "\n" + "Int: " + itemIntelligence + "\n" + "Str: " + itemStrength + "\n" + "Agi: " + itemAgility + "\n" + "Lck: " + itemLuck + "</color>";
            case (ItemType.Trinket):
                return RarityColour(itemRarity) + itemName + "\n" + tooltip + "\n" + "Health: " + itemHealth + "\n" + "Mana: " + itemMana + "\n" + "Int: " + itemIntelligence + "\n" + "Str: " + itemStrength + "\n" + "Agi: " + itemAgility + "\n" + "Lck: " + itemLuck + "</color>";
        }
        return itemType.ToString();
    }
    
    private string RarityColour(ItemRarity rarity)
    {
        switch (rarity)
        {
            case (ItemRarity.common):
                return "<color=#ffffff>";
            case (ItemRarity.uncommon):
                return "<color=#44ff44>";
            case (ItemRarity.rare):
                return "<color=#4444ff>";
            case (ItemRarity.epic):
                return "<color=#cc44cc>";
            case (ItemRarity.legendary):
                return "<color=#ff8833>";
            case (ItemRarity.demonic):
                return "<color=#ff2222>";
            case (ItemRarity.heavenly):
                return "<color=#ffff55>";
        }
        return rarity.ToString();
    }
}

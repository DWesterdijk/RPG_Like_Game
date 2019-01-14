using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_DB : MonoBehaviour {
    public List<Item_Attributes> itemList = new List<Item_Attributes>();

    private void Awake()
    {
        //Weapons
        itemList.Add(new Item_Attributes("testSword", "A test sword", 0, 5000, 0, 0, 0, 0, 0, 0, 0, Item_Attributes.ItemType.Weapon, Item_Attributes.ItemRarity.common));

        //Armours
        itemList.Add(new Item_Attributes("TestArmour", "A TestArmour", 1, 0, 5000, 0, 0, 0, 0, 0, 0, Item_Attributes.ItemType.Armour, Item_Attributes.ItemRarity.legendary));

        //Trinkets
        itemList.Add(new Item_Attributes("TestTrinket", "A TestTrinket", 2, 0, 0, 100, 100, 100, 100, 100, 100, Item_Attributes.ItemType.Trinket, Item_Attributes.ItemRarity.epic));

        //Necklaces
        itemList.Add(new Item_Attributes("TestNecklace", "A TestNecklace", 3, 0, 0, 500, 500, 500, 500, 500, 500, Item_Attributes.ItemType.Necklace, Item_Attributes.ItemRarity.demonic));
    }
}

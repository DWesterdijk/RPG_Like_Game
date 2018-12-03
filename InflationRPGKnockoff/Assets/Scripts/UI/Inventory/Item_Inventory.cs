using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Inventory : MonoBehaviour {
    public byte slotsX, slotsY;

    [SerializeField]
    private List<Item_Attributes> _inventory = new List<Item_Attributes>();
    [SerializeField]
    private List<Item_Attributes> _slots = new List<Item_Attributes>();
    [SerializeField]
    private List<Item_Attributes> _weapon = new List<Item_Attributes>();
    private List<Item_Attributes> _armour = new List<Item_Attributes>();
    private List<Item_Attributes> _necklace = new List<Item_Attributes>();
    private List<Item_Attributes> _trinket = new List<Item_Attributes>();

    [SerializeField]
    private GUISkin _guiSKin;
    
    private bool _showInv;
    private bool _showTT;
    private bool _dragItem;

    private string _stringTT;

    private int _dragIndex;

    private Item_DB _iDB;

    private Item_Attributes _DraggedItem;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            _slots.Add(new Item_Attributes());
            _inventory.Add(new Item_Attributes());
        }

        _weapon.Add(new Item_Attributes());
        _armour.Add(new Item_Attributes());
        _necklace.Add(new Item_Attributes());

        for (int j = 0; j < 3; j++)
        {
            _trinket.Add(new Item_Attributes());
        }

        _iDB = GameObject.Find("ItemDB").GetComponent<Item_DB>();

        AddItem(0);
        AddItem(1);
        AddItem(2);
        AddItem(3);
    }

    private void Update()
    {   
        if (Input.GetButtonDown("inv"))
        {
            _showInv = !_showInv;
            if (_showInv)
            {
                //LoadInv();
            }
            if (!_showInv)
            {
                //SaveInv();
            }
        }
    }

    private void OnGUI()
    {
        _stringTT = "";
        GUI.skin = _guiSKin;

        if (_showInv)
        {
            DrawInventory();
            if (_showTT)
            {
                GUI.Box(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 200, 200), _stringTT, _guiSKin.GetStyle("InvTT"));
            }
        }
        if (_dragItem)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 35, 35), _DraggedItem.itemIco);
        }
        
    }

    void DrawInventory()
    {
        Event e = Event.current;

        int i = 0;


        GUI.Box(new Rect(0, 0, 285, 340), "", _guiSKin.GetStyle("InvBG"));
        GUI.Box(new Rect(285, 0, 285, 340), "", _guiSKin.GetStyle("InvBG"));
        Rect emptyWep = new Rect(292.5f, 7.5f, 50, 50);
        Rect emptyArm = new Rect(292.5f, 57.5f + 7.5f, 50, 50);
        Rect emptyNeck = new Rect(292.5f, 107.5f + 15f, 50, 50);
        Rect emptyTrink1 = new Rect(292.5f, 157.5f + 22.5f, 50, 50);
        Rect emptyTrink2 = new Rect(292.5f, 207.5f + 30f, 50, 50);
        Rect emptyTrink3 = new Rect(292.5f, 257.5f + 37.5f, 50, 50);
        GUI.Box(emptyWep, "", _guiSKin.GetStyle("EmptySlot(Weapon)"));
        GUI.Box(emptyArm, "", _guiSKin.GetStyle("EmptySlot(Armour)"));
        GUI.Box(emptyNeck, "", _guiSKin.GetStyle("EmptySlot(Necklace)"));
        GUI.Box(emptyTrink1, "", _guiSKin.GetStyle("EmptySlot(Trinket)"));
        GUI.Box(emptyTrink2, "", _guiSKin.GetStyle("EmptySlot(Trinket)"));
        GUI.Box(emptyTrink3, "", _guiSKin.GetStyle("EmptySlot(Trinket)"));

        for (int y = 0; y < slotsY; y++)
        {
            for (int x = 0; x < slotsX; x++) 
            {
                Rect slotRect = new Rect((x * 55) + 7.5f, (y * 55) + 7.5f, 50, 50);
                GUI.Box(slotRect, "", _guiSKin.GetStyle("InvSlot"));
                _slots[i] = _inventory[i];
                if (_slots[i].itemName != null)
                {
                    GUI.DrawTexture(slotRect, _slots[i].itemIco);
                    if (slotRect.Contains(e.mousePosition))
                    {
                        _stringTT = GetTooltip(_slots[i]);
                        _showTT = true;
                        if (e.button == 0 && e.type == EventType.MouseDrag && !_dragItem)
                        {
                            _dragItem = true;
                            _dragIndex = i;
                            _DraggedItem = _slots[i];
                            _inventory[i] = new Item_Attributes();
                        }
                        if (e.type == EventType.MouseUp && _dragItem)
                        {
                            _inventory[_dragIndex] = _inventory[i];
                            _inventory[i] = _DraggedItem;
                            _dragItem = false;
                            _DraggedItem = null;
                        }
                    }
                }
                else
                {
                    if (slotRect.Contains(e.mousePosition))
                    {
                        if (e.type == EventType.MouseUp && _dragItem)
                        {
                            _inventory[i] = _DraggedItem;
                            _dragItem = false;
                            _DraggedItem = null;
                        }
                    }
                }
                if (_stringTT == "")
                {
                    _showTT = false;
                }
                i++;
            }
        }
    }

    string GetTooltip(Item_Attributes itemAttribute)
    {
        _stringTT += itemAttribute.ItemStats();

        return _stringTT;
    }

    void RemoveItem(int itemID)
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i].itemID == itemID)
            {
                _inventory[i] = new Item_Attributes();
                break;
            }
        }
    }

    void AddItem(int itemID)
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i].itemName == null)
            {
                for (int j = 0; j < _iDB.itemList.Count; j++)
                {
                    if (_iDB.itemList[j].itemID == itemID)
                    {
                        _inventory[i] = _iDB.itemList[j];
                    }
                }
                break;
            }
        }
    }

    bool CheckInventory(int itemID)
    {
        bool isItemInInv = false;
        for (int i = 0; i < _inventory.Count; i++)
        {
            isItemInInv = _inventory[i].itemID == itemID;
            if (isItemInInv)
            {
                break;
            }
        }
        return isItemInInv;
    }

    void SaveInv()
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            PlayerPrefs.SetInt("Inventory " + i, _inventory[i].itemID);
        }
    }

    void LoadInv()
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            _inventory[i] = PlayerPrefs.GetInt("Inventory " + i, -1) >= 0 ? _iDB.itemList[PlayerPrefs.GetInt("Inventory " + i)] : new Item_Attributes();
        }
    }
}

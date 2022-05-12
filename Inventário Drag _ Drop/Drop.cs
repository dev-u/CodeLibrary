using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    InventorySlot slot;
    [SerializeField]
    int provaId;

    private void Start()
    {
        slot = GetComponent<InventorySlot>();
    }

    public void OnDrop(PointerEventData pointerData)
    {
        Item item = pointerData.pointerDrag.transform.parent.GetComponent<InventorySlot>().GetItem();
        SaveNotes saveNotes = transform.parent.parent.parent.GetComponent<SaveNotes>();
        if (item != null && item.id != saveNotes.idProva1 && item.id != saveNotes.idProva2 && item.id != saveNotes.idProva3)
        {
            if(slot.GetItem() != null)
            {
                slot.ClearSlot();
            }
            slot.AddItem(item);
            if(provaId == 1)
            {
                saveNotes.idProva1 = item.id;
            }else if(provaId == 2)
            {
                saveNotes.idProva2 = item.id;
            }
            else if (provaId == 3)
            {
                saveNotes.idProva3 = item.id;
            }
        }
    }
}

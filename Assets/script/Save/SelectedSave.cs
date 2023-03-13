using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedSave : MonoBehaviour
{
    private int saveSelect;
     
    public string getSaveSelected()
    {
        string saveSlot;
        if(this.saveSelect == 1)
        {
            saveSlot = "_Slot1";         
        }
        else if (this.saveSelect == 2)
        {
            saveSlot = "_Slot2";        
        }
        else if (this.saveSelect == 3)
        {
            saveSlot = "_Slot3";
        }
        else
        {
            saveSlot = "_Slot0";
        }
        return saveSlot;
    }

    public void setSaveSelected(int saveSlot)
    {
        this.saveSelect = saveSlot;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.UI;
using Inventory.Model;

public class CanvasManager : MonoBehaviour
{
    public UIInventoryPage UIInventoryPage;
    public static CanvasManager instance;
    private void Awake()
    {
        instance = this;
    }
}

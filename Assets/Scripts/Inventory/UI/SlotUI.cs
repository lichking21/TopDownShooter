using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text count;

    void Awake() => icon.enabled = false;

    public void SetData(ItemSlot item)
    {
        icon.sprite = item.Item.Icon;
        icon.enabled = true;
        count.text = item.Count > 1 ? item.Count.ToString() : ""; 
    }
    public void Clear()
    {
        icon.enabled = false;
        count.text = "";
    }
}
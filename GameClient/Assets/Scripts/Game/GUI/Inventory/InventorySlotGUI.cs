using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotGUI : MonoBehaviour, IDropHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    private ItemGUI _itemGUI;
    private InventorySlot _slot;

    public void OnBeginDrag(PointerEventData eventData) {
        if (_slot.Item != null)
            DragAndDropGUI.Current.StartDrag(_slot.Item.Icon);
    }

    public void OnEndDrag(PointerEventData eventData) {
        DragAndDropGUI.Current.StopDrag();
    }

    public void OnDrag(PointerEventData eventData) {
    }

    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag.TryGetComponent(out InventorySlotGUI otherSlotGUI))
            _slot.Swap(otherSlotGUI.Slot);
    }

    public void OnChanged(Item item, int amount) {
        _itemGUI.Initialize(item, amount);
    }

    public void Initialize(InventorySlot slot) {
        slot.OnChanged += OnChanged;
        _slot = slot;
    }

    public InventorySlot Slot => _slot;
}
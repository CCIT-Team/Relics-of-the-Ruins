// using UnityEngine;
// using UnityEngine.EventSystems;

// namespace Inventory
// {
//     public class GridInteractor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
//     {
//         private InventoryController _inventoryController;
//         private InventoryBase _inventory;
//         public void OnPointerEnter(PointerEventData eventData)
//         {
//             _inventoryController.SetInventory(_inventory);
//         }

//         public void OnPointerExit(PointerEventData eventData)
//         {
//             _inventoryController.UnsetInventory(_inventory);
//         }

//         public void Setup(InventoryBase inventory)
//         {
//             _inventory = inventory;
//         }

//         public void Awake()
//         {
//             _inventoryController = FindObjectOfType<InventoryController>();
//         }
//     }

// }
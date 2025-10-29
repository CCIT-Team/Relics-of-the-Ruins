
// using UnityEngine;

// namespace RelicsOfTheRuins.Utilities
// {
//     public class InventoryCalcUtils
//     {
//         public static Vector2Int GetClickedCellCoord(in Vector2 mousePos, in Vector2Int cellSize,in Vector3 girdPos)
//         {
//             Vector2 pOnGrid = new Vector2(mousePos.x - girdPos.x, girdPos.y - mousePos.y);
//             Vector2Int tilepos = new Vector2Int((int)(pOnGrid.x / cellSize.x), (int)(pOnGrid.y / cellSize.y));
//             return tilepos;
//         }

//         public static Vector2 CalculateSpriteGridPos(Vector2Int gridPos,in Vector2Int cellSize)
//         {
//             gridPos.x = gridPos.x * cellSize.x;
//             gridPos.y = -(gridPos.y * cellSize.y);
//             return gridPos;
//         }

//         public static bool BoundaryCheck(Vector2Int invPos,Vector2Int targetSiz,Vector2Int invMaxPos)
//         {
//             if (invPos.x < 0 || invPos.y < 0)
//             {
//                 return false;
//             }

//             if (invPos.x + targetSiz.x > invMaxPos.x || invPos.y + targetSiz.y > invMaxPos.y)
//             {
//                 return false;
//             }

//             return true;
//         }
//     }
// }
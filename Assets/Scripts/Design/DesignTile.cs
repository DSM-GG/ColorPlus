using Board.Tile;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Design
{
    public class DesignTile : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
    {
        // 인스펙터 비노출 변수
        // 일반
        private Tile                tile;                        // 타일 스크립트
        private TileColorManager    tileColorManager;            // 타일 색 설정 스크립트
        
        
        // 초기화
        private void Awake()
        {
            GetComponent<TileClick>().enabled = false;
            
            tile              = GetComponent<Tile>();
            tileColorManager  = GetComponent<TileColorManager>();
        }
        
        // 마우스 클릭
        public void OnPointerDown(PointerEventData eventData)
        {
            ChangeTile();
        }
        
        // 마우스 클릭상태 드래그
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (Input.GetMouseButton(0))
            {
                ChangeTile();
            }
        }
        
        // 타일 변경
        private void ChangeTile()
        {
            tileColorManager.SetColor(BrushManager.instance.brushColor);
        }
    }
}

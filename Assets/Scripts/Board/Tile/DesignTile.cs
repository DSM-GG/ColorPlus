using UnityEngine;
using UnityEngine.EventSystems;

namespace Board.Tile
{
    public class DesignTile : MonoBehaviour, IPointerClickHandler
    {
        // 인스펙터 비노출 변수
        // 일반
        private Tile                tile;                        // 타일 스크립트
        private TileColorManager    tileColorManager;            // 타일 색 설정 스크립트
        
        // 수치
        private int                 tileTypeCount;                // 타일 종류 갯수
        
        
        // 초기화
        private void Awake()
        {
            GetComponent<TileClick>().enabled = false;
            
            tile              = GetComponent<Tile>();
            tileColorManager  = GetComponent<TileColorManager>();

            tileTypeCount     = BoardManager.instance.tileSprites.Length;
        }

        // 마우스 클릭
        public void OnPointerClick(PointerEventData eventData)
        {
            tileColorManager.SetColor((++tile.colorNum) % tileTypeCount);
        }
    }
}

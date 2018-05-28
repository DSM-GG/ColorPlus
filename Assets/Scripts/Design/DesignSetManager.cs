using System.Collections.Generic;
using Board;
using Board.Tile;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Design
{
	public class DesignSetManager : MonoBehaviour
	{
		// 인스펙터 노출 변수
		[SerializeField]
		private Tile[] 	paletteArray;				// 파레트 모음
		
		
		// 셋팅
		public void SettingDesign(InputField inField)
		{
			// 보드 셋팅		
			List<int> resultData = new List<int>();
			string[]  splitStr   = inField.text.Split();
			int 	  size 	     = int.Parse(splitStr[0]);	

			
			UIManager.instance.SetUI(0, true);
			
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					resultData.Add(1);
				}
			}
			
			// 보드 셋팅
			BoardManager.instance.SetSize(size, size);
			
			BoardManager.instance.tileSpriteIndArr = resultData.ToArray();
			BoardManager.instance.Initialize();
			
			// 파레트 셋팅
			for (int i = 1; i < paletteArray.Length; i++)
			{
				paletteArray[i].Initialize(-1, -1, i);
			}
			
			UIManager.instance.SetUI(2, false);
		}
	}
}

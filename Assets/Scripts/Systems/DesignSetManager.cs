using System.Collections.Generic;
using Board;
using UnityEngine;
using UnityEngine.UI;

namespace Systems
{
	public class DesignSetManager : MonoBehaviour
	{
		// 셋팅
		public void SettingDesign(InputField inField)
		{	
			string[] splitStr = inField.text.Split();
			int height 	= int.Parse(splitStr[0]);
			int width 	= int.Parse(splitStr[1]);
			
			
			UIManager.instance.SetUI(0, true);
			UIManager.instance.SetUI(1, true);
			
			BoardManager.instance.SetSize(height, width);
			
			// 타일 초기화
			List<int> resultData = new List<int>();
			
			
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					resultData.Add(1);
				}
			}

			BoardManager.instance.tileSpriteIndArr = resultData.ToArray();
			BoardManager.instance.Initialize();
			
			UIManager.instance.SetUI(2, false);
		}
	}
}

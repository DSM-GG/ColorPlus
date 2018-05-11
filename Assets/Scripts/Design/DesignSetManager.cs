using System.Collections.Generic;
using Systems;
using Board;
using UnityEngine;
using UnityEngine.UI;

namespace Design
{
	public class DesignSetManager : MonoBehaviour
	{
		// 셋팅
		public void SettingDesign(InputField inField)
		{	
			string[] splitStr = inField.text.Split();
			int size 	= int.Parse(splitStr[0]);
			
			
			UIManager.instance.SetUI(0, true);
			UIManager.instance.SetUI(1, true);
			
			BoardManager.instance.SetSize(size, size);
			
			// 타일 초기화
			List<int> resultData = new List<int>();
			
			
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
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

using System.IO;
using Board;
using UnityEngine;
using UnityEngine.UI;

namespace Design
{
	public class DesignSaveManager : MonoBehaviour
	{	
		// 현재 상태 저장
		public void SaveTile(InputField inField)
		{
			int 	 size = BoardManager.instance.height;
			string[] stringDatas = new string[size + 1];

			
			stringDatas[0] = inField.text + " " + size;
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					stringDatas[i + 1] += BoardManager.instance.tileArray[i, j].colorNum + " ";
				}
			}
			
			File.WriteAllLines(@"Assets/Datas/NewTiles.txt", stringDatas);
		}
	}
}

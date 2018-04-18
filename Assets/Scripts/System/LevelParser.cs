using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser
{
	// 일반
	string dataPath = "Assets/Resources/LevelData/";


	// 데이터 파싱
	public void Parse(int level)
	{
		// 경로 설정 및 데이터 파싱
		string		 finalPath = dataPath + level.ToString() + ".txt";
		
		FileStream	 fs	 	   = new FileStream(finalPath, FileMode.Open);
		StreamReader sr	  	   = new StreamReader(fs);


		// 선행 데이터 초기화
		string	 source    = sr.ReadLine();
		string[] firstData = source.Split();
		int		 size	   = int.Parse(firstData[1]);

		GameManager.instance.originalTurn = int.Parse(firstData[0]);
		Board.instance.width  = size;
		Board.instance.height = size;
		

		// 타일 초기화
		List<int> resultData = new List<int>();

		source = sr.ReadLine();
		for (int i = 0; i < size; i++)
		{
			string[] lineOfData = source.Split();

			for (int j = 0; j < size; j++)
			{
				resultData.Add(int.Parse(lineOfData[j]));
			}

			source = sr.ReadLine();
		}

		Board.instance.tileColorType = resultData.ToArray();
	}
}

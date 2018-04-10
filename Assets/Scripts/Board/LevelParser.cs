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
		string finalPath = dataPath + level.ToString() + ".txt";
		
		FileStream fs = new FileStream(finalPath, FileMode.Open);
		StreamReader sr = new StreamReader(fs);

		string source = sr.ReadLine();


		// 가로 세로 초기화
		int size = int.Parse(source);
		Board.instance.width = size;
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

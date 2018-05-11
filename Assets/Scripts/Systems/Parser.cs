using System.Collections.Generic;
using System.IO;
using Board;

namespace Systems
{
	public class Parser
	{
		public static Parser instance;

		// 일반
		private const string DataPath = "Assets/Datas/";
		
		
		// 싱글톤 초기화
		public static void Init()
		{
			if (instance == null)
			{
				instance = new Parser();
			}
		}
		
		// 생성자
		private Parser()
		{
		}

		// 데이터 파싱
		public void Parse(int level)
		{
			// 경로 설정 및 데이터 불러오기
			string			finalPath = DataPath + level.ToString() + ".txt";
		
			FileStream		fs = new FileStream(finalPath, FileMode.Open);
			StreamReader	sr = new StreamReader(fs);


			// 선행 데이터 초기화
			string		source = sr.ReadLine();
			string[]	firstData = source.Split();

			int			size = int.Parse(firstData[1]);


			GameManager.instance.originalTurnCount = int.Parse(firstData[0]);
			BoardManager.instance.SetSize(size, size);
			
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

			BoardManager.instance.tileSpriteIndArr = resultData.ToArray();
			
			fs.Close();
		}
	}
}


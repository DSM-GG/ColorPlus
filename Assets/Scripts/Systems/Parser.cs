using System.Collections.Generic;
using System.IO;
using Board;
using UnityEngine;

namespace Systems
{
	public class Parser
	{
		public static Parser instance;

		// 일반
		private string DataPath = "/Resources/Datas/";
		
		
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
			TextAsset 	levelTextAsset 	= Resources.Load<TextAsset>("Datas/" + level.ToString());
			string 		levelText 		= levelTextAsset.text;
			string[] 	levelTextLayer 	= levelText.Split('\n');
			string[] 	levelTextFirst 	= levelTextLayer[0].Split(' ');
			int 		size 			= int.Parse(levelTextFirst[1]);
			
			GameManager.instance.originalTurnCount = int.Parse(levelTextFirst[0]);
			BoardManager.instance.SetSize(size, size);
			
			List<int> resultData = new List<int>();
			
			for (int i = 1; i < size + 1; i++)
			{
				string target = levelTextLayer[i];
				string[] targetSplit = target.Split(' ');
				
				for (int j = 0; j < size; j++)
				{
					resultData.Add(int.Parse(targetSplit[j]));	
				}
			}
			
			
			// 경로 설정 및 데이터 불러오기
//			string			finalPath = pathForDocumentsFile() + DataPath + level.ToString() + ".txt";
//
//			FileStream		fs = new FileStream(finalPath, FileMode.Open);
//			StreamReader	sr = new StreamReader(fs);
//
//
//			// 선행 데이터 초기화
//			string		source = sr.ReadLine();
//			string[]	firstData = source.Split();
//
//			int			size = int.Parse(firstData[1]);
//
//
//			//GameManager.instance.originalTurnCount = int.Parse(firstData[0]);
//			//BoardManager.instance.SetSize(size, size);
//			
//			// 타일 초기화
//			List<int> resultData = new List<int>();
//		
//
//			source = sr.ReadLine();
//			for (int i = 0; i < size; i++)
//			{
//				string[] lineOfData = source.Split();
//
//				for (int j = 0; j < size; j++)
//				{
//					resultData.Add(int.Parse(lineOfData[j]));
//				}
//
//				source = sr.ReadLine();
//			}

			BoardManager.instance.tileSpriteIndArr = resultData.ToArray();
			
//			fs.Close();
		}
		
		// 플랫폼 경로 변경
		public string pathForDocumentsFile()
		{
			string path;
			
			if (Application.platform == RuntimePlatform.IPhonePlayer)
			{
				path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
				path = Path.Combine(path, "Documents");
			}
			else if (Application.platform == RuntimePlatform.Android)
			{
				path = Application.persistentDataPath;
			} 
			else 
			{
				path = Application.dataPath;
			}
			
			return path;
		}
	}
}


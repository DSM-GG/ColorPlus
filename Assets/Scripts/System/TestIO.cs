using UnityEngine;

namespace System
{
	public class TestIO : MonoBehaviour
	{
		// 프레임
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				BoardManager.instance.Restore();
			}
			
			if (Input.GetKeyDown(KeyCode.R))
			{
				BoardManager.instance.ResetTile();
			}
		}
	}
}

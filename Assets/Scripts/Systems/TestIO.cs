using UnityEngine;

namespace Systems
{
	public class TestIo : MonoBehaviour
	{
		// 프레임
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				PlayerPrefs.DeleteAll();
			}
		}
	}
}

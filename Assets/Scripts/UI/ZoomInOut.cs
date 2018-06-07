using UnityEngine;

namespace UI
{
	public class ZoomInOut : MonoBehaviour
	{
		// 매 프레임
		private void Update()
		{
			if (Input.touchCount == 2)
			{
				Touch 	touchZero 	= Input.GetTouch(0);
				Touch 	touchOne 	= Input.GetTouch(1);

				Vector2 touchZeroPrevPos 	= touchZero.position - touchZero.deltaPosition;
				Vector2 touchOnePrevPos 	= touchOne.position - touchOne.deltaPosition;

				float 	prevTouchDeltaMag 	= (touchZeroPrevPos - touchOnePrevPos).magnitude;
				float 	touchDeltaMag 		= (touchZero.position - touchOne.position).magnitude;

				float 	deltaMagnitudediff = prevTouchDeltaMag - touchDeltaMag;
				
				Debug.Log(deltaMagnitudediff);
			}
		}
	}
}

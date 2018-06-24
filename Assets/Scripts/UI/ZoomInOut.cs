using UnityEngine;

namespace UI
{
	public class ZoomInOut : MonoBehaviour
	{
		// 인스펙터 비노출 변수
		// 수치
		private Vector3 scaleVector = new Vector3(1, 1, 0);

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

				Vector3 newScale		   = scaleVector * deltaMagnitudediff * 0.01f;
				float	scaleConst		   = Mathf.Max(1f, Mathf.Min(newScale.x, 5));
				Vector3 finalScale		   = new Vector3(scaleConst, scaleConst, 0);

				transform.localScale = finalScale;
			}
		}
	}
}

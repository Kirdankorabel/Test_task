using System.Collections;
using UnityEngine;

namespace KnifeScripts
{
	public class KnifeMover : MonoBehaviour
	{
		[SerializeField] private float _moveSpeed = 5f;
		[SerializeField] private float _finishMoveSpeed = 20f;
		[SerializeField] private bool _isFinished = false;

		private void OnEnable()
		{
			KnifeController.Singltone.PlayerFinished += Finished;
			GameController.Singletone.StartLevel += () => _isFinished = false;
		}

		private void Update()
		{
			StartCoroutine(MoveCoroutine());
			if (!_isFinished) HorisontalMove();
		}

		public void Finished()
		{
			_isFinished = true;
			transform.position = new Vector3(0, 2, transform.position.z);
		}

		private void HorisontalMove()
		{
			RaycastHit hit;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				var pos = hit.point.x / 2;
				if (pos < -1) transform.position = new Vector3(-1, 2, transform.position.z);
				else if (pos > 1) transform.position = new Vector3(1, 2, transform.position.z);
				else transform.position = new Vector3(pos, 2, transform.position.z);
			}
		}

		IEnumerator MoveCoroutine()
		{
			if (!_isFinished)
				transform.position += Vector3.forward * _moveSpeed * Time.deltaTime;
			else
				transform.position += Vector3.forward * _finishMoveSpeed * Time.deltaTime;
			yield return null;
		}
	}
}

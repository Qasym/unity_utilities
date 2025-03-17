using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace qasym.Utils.Monobehaviours
{
	public class DelayedInvoker : MonoBehaviour
	{
		#region Events

		public UnityEvent DelayReached = new();

		#endregion

		#region Public Methods

		public void InvokeAfter(float seconds) => StartCoroutine(InvokeAfterRoutine(seconds));

		public async void InvokeAfterAsync(float seconds)
		{
			await Task.Delay((int)(seconds * 1000f));
			DelayReached.Invoke();
		}

		#endregion

		#region Helper Methods

		public IEnumerator InvokeAfterRoutine(float seconds)
		{
			yield return new WaitForSeconds(seconds);
			DelayReached.Invoke();
		}

		#endregion
	}

#if UNITY_EDITOR

	[UnityEditor.CustomEditor(typeof(DelayedInvoker))]
	[UnityEditor.CanEditMultipleObjects]
	public class DelayedInvokerEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
		}
	}

#endif

}

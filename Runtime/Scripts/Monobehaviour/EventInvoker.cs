using UnityEngine;
using UnityEngine.Events;

namespace qasym.Utils.Monobehaviours
{
    public class EventInvoker : MonoBehaviour
    {
		#region Members

		public UnityEvent Event = new();

		#endregion

		#region Public Methods

		public void InvokeEvent() => Event.Invoke();

		#endregion
	}

#if UNITY_EDITOR

	[UnityEditor.CustomEditor(typeof(EventInvoker))]
	[UnityEditor.CanEditMultipleObjects]
	public class EventInvokerEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			EventInvoker eventInvoker = (EventInvoker)target;
			if (GUILayout.Button("Invoke Event"))
			{
				eventInvoker.InvokeEvent();
			}
		}
	}

#endif

}

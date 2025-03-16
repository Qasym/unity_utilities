using UnityEngine;

namespace qasym.Utils.Monobehaviours
{
	[RequireComponent(typeof(Rigidbody))]
	[ExecuteInEditMode]
    public class CenterOfMassVisualizer : MonoBehaviour
    {
		#region Members

		[SerializeField] private Color _gizmoColor = Color.black;
		[Range(0f, 1f)]
		[SerializeField] private float _gizmoRadius;
		private Rigidbody _rigidBody;

		#endregion

		#region Unity Callbacks

		private void Awake()
		{
			_rigidBody = GetComponent<Rigidbody>();
		}

		private void OnDrawGizmos()
		{
			if (_rigidBody == null)
				return;
			Gizmos.color = _gizmoColor;
			Gizmos.DrawSphere(_rigidBody.worldCenterOfMass, _gizmoRadius);
		}

		#endregion
	}
}

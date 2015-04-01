using UnityEngine;

namespace JZLTools.Spawning
{
	public abstract class PrefabSpawner<KEY, VALUE> : SpawnerBase<KEY, VALUE>
		where VALUE : MonoBehaviour, ISpawnable<KEY>
	{
		protected abstract GameObject PrefabForKey (KEY key);

		protected override VALUE CreateNew (KEY key)
		{
			var prefab = PrefabForKey(key);
			var go = Instantiate (prefab);
			return go.GetComponent<VALUE> ();
		}
	}
}


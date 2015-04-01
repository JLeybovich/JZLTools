using System.Collections.Generic;
using UnityEngine;

namespace JZLTools.Spawning
{
	public abstract class SpawnerBase<KEY, VALUE> : MonoBehaviour 
		where VALUE : ISpawnable<KEY>
	{
		readonly Dictionary<KEY, Stack<VALUE>> _recycleBin = new Dictionary<KEY, Stack<VALUE>> ();

		public VALUE Spawn(KEY key)
		{
			VALUE spawnedObj;
			if(_recycleBin.ContainsKey(key) && _recycleBin[key].Count > 0)
			{
				spawnedObj = _recycleBin[key].Pop ();
				spawnedObj.Respawn (key);
			}
			else
			{
				spawnedObj = CreateNew (key);
			}
				
			return spawnedObj;
		}

		protected abstract VALUE CreateNew (KEY key);

		public void Despawn(VALUE obj)
		{
			var spawnKey = obj.SpawnKey;
			if(!_recycleBin.ContainsKey(spawnKey))
			{
				_recycleBin[spawnKey] = new Stack<VALUE> ();
			}

			obj.Despawn ();
			_recycleBin[spawnKey].Push (obj);
		}
	}
}


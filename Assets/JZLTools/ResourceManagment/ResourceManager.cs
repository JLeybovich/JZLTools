using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace JZLTools.ResourceManagment
{
	public class ResourceManager
	{
		Dictionary<string, Object> ResourceCache { get; set; }

		protected ResourceManager ()
		{
			ResourceCache = new Dictionary<string, Object> ();
		}

		public Object GetResource(string path)
		{
			return GetResource<Object>(path);
		}

		public TResource GetResource<TResource>(string path) where TResource : Object
		{
			Object obj;
			if(ResourceCache.TryGetValue(path, out obj))
			{
				return obj as TResource;
			}

			obj = Resources.Load<TResource> (path);
			ResourceCache.Add (path, obj);

			return obj as TResource;
		}

		public Material GetSharedMaterial(string name)
		{
			var path = Path.Combine (ResourcePaths.MaterialPath, name);
			return GetResource<Material>(path);
		}

		public GameObject GetPrefab(string name)
		{
			var path = Path.Combine (ResourcePaths.PrefabsPath, name);
			return GetResource<GameObject>(path);
		}

		public AudioClip GetAudioClip(string name)
		{
			var path = Path.Combine (ResourcePaths.AudioPath, name);
			return GetResource<AudioClip>(path);
		}
	}
}
	
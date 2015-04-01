
namespace JZLTools.Spawning
{
	public interface ISpawnable<KEY>
	{
		KEY SpawnKey { get; }
		void Respawn (KEY key);
		void Despawn ();
	}
}


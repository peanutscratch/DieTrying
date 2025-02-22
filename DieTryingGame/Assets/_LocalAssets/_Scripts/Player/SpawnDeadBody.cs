using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using System.Linq;

namespace MoreMountains.TopDownEngine
{
	/// <summary>
	/// Add this component to a character and it will spawn a prefab on death
	/// </summary>
	[AddComponentMenu("TopDown Engine/Character/Abilities/Character Spawn Body on Death")]
	public class SpawnDeadBody : TopDownMonoBehaviour
	{
        
        /// the feedback to play when spawning the body
		[Tooltip("the feedback to play when spawning prefabs")]
		public MMFeedbacks SpawningBodyFeedback;

        
        /// the list to store and initialize bodies
		[Tooltip("the list to store and initialize prefabs within")]
		public DeadBodyManager deadBodyManager;

        /// A list of prefabs to spawn on death
		[Tooltip("A list of prefabs to spawn on death")]
		public List<GameObject> ObjectsToSpawnOnDeath;

		/// A list of optional objects to disable on death
		[Tooltip("A list of optional objects to disable on death")]
		public List<GameObject> ObjectsToDisableOnDeath;
		/// A list of optional monos to disable on death
		[Tooltip("A list of optional monos to disable on death")]
		public List<MonoBehaviour> MonosToDisableOnDeath;


		[Header("Test")]
		/// A test button to trigger the spawning from the inspector
		[MMInspectorButton("Spawn Body")]
		[Tooltip("A test button to trigger spawning prefabs from the inspector")]
        public bool SpawnBodyButton;

        
		protected TopDownController _controller;
		protected Health _health;
		protected Transform _initialParent;
		protected Vector3 _initialPosition;
		protected Quaternion _initialRotation;
		protected Character _character;
        
		/// <summary>
		/// On Awake we initialize our component
		/// </summary>
		protected virtual void Start()
		{
			Initialization();
		}

        
		/// <summary>
		/// Grabs our health and controller
		/// </summary>
		protected virtual void Initialization()
		{
			if (_health == null)
			{
				GrabHealth();
			}
			_controller = this.gameObject.GetComponent<TopDownController>();

		}

		protected virtual void GrabHealth()
		{
			_character = this.gameObject.GetComponentInParent<Character>();
			_health = (_character != null) ? _character.CharacterHealth : this.gameObject.GetComponent<Health>();
			if (_health != null)
			{
				_health.OnDeath += OnDeath;
			}
		}

        
		/// <summary>
		/// When we get a OnDeath event, we spawn prefabs
		/// </summary>
		protected virtual void OnDeath()
		{
			SpawnBody();
		}

        /// <summary>
		/// Disables the specified objects and monos and spawns a body at the location of death
		/// </summary>
		protected virtual void SpawnBody()
		{
			foreach (GameObject go in ObjectsToDisableOnDeath)
			{
				go.SetActive(false);
			}
			foreach (MonoBehaviour mono in MonosToDisableOnDeath)
			{
				mono.enabled = false;
			}

            foreach (GameObject spawnPrefab in ObjectsToSpawnOnDeath)
            {
                GameObject temp = Instantiate(spawnPrefab, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z), Quaternion.identity) as GameObject;
                deadBodyManager.deadBodies.Add(temp);
                
                if(deadBodyManager.deadBodies.Count > deadBodyManager.bodyCountCap)
                {
                    GameObject body = deadBodyManager.deadBodies.ElementAt(0);
                    
                    Destroy(body);
                    deadBodyManager.deadBodies.RemoveAt(0);
                }
            }
		}

        
		/// <summary>
		/// OnDestroy we stop listening to OnDeath events
		/// </summary>
		protected virtual void OnDestroy()
		{
			if (_health != null)
			{
				_health.OnDeath -= OnDeath;
			}
		}


    }
}

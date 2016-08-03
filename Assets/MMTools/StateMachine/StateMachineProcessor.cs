using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using MoreMountains.Tools;
using System;
using System.Collections.Generic;

namespace MoreMountains.Tools
{
	/// <summary>
	/// State machine processor. Add this component to an object and it'll trigger events for all the state machines you'll feed it.
	/// Example :
	/// MovementStateMachine = new StateMachine<MovementStates>(GetInstanceID(),true); // declares new state machine
	/// ConditionStateMachine = new StateMachine<CharacterConditions>(GetInstanceID(),true);
	/// StateMachineProcessor processor = gameObject.AddComponent<StateMachineProcessor>(); // adds a processor component 
	/// processor.Initialization(); // initializes it
	/// processor.AddStateMachine(MovementStateMachine); // adds state machines to the processor
	/// processor.AddStateMachine(ConditionStateMachine);
	///
	/// Then you just have to listen to the events (see StateMachine.cs for details on that)
	/// </summary>
	public class StateMachineProcessor : MonoBehaviour 
	{
		protected List<IStateMachine> _stateMachines;

		/// <summary>
		/// Call this to initialize the processor, before adding any state machine to it
		/// </summary>
		public virtual void Initialization()
		{
			_stateMachines = new List<IStateMachine>();
		}

		/// <summary>
		/// Adds a state machine to the processor
		/// </summary>
		/// <param name="newStateMachine">New state machine.</param>
		public virtual void AddStateMachine(IStateMachine newStateMachine)
		{
			_stateMachines.Add(newStateMachine);
		}

		/// <summary>
		/// Empties the processor's list.
		/// </summary>
		public virtual void EmptyList()
		{
			_stateMachines.Clear();
		}

		/// <summary>
		/// Triggers the state machine's FixedUpdate events
		/// </summary>
		protected virtual void FixedUpdate()
		{
			foreach (IStateMachine stateMachine in _stateMachines)
			{
				if (stateMachine.TriggerEvents)
				{
					stateMachine.FixedUpdate();
				}
			}
		}

		/// <summary>
		/// Triggers the state machine's Update events, in that order : EarlyUpdate, Update, EndOfUpdate
		/// </summary>
		protected virtual void Update()
		{
			foreach (IStateMachine stateMachine in _stateMachines)
			{
				if (stateMachine.TriggerEvents)
				{
					stateMachine.EarlyUpdate();
				}
			}
			foreach (IStateMachine stateMachine in _stateMachines)
			{
				if (stateMachine.TriggerEvents)
				{
					stateMachine.Update();
				}
			}
			foreach (IStateMachine stateMachine in _stateMachines)
			{
				if (stateMachine.TriggerEvents)
				{
					stateMachine.EndOfUpdate();
				}
			}
		}

		/// <summary>
		/// Triggers the state machine's LateUpdate events
		/// </summary>
		protected virtual void LateUpdate()
		{
			foreach (IStateMachine stateMachine in _stateMachines)
			{
				if (stateMachine.TriggerEvents)
				{
					stateMachine.LateUpdate();
				}
			}
		}

	}
}
using BlazorVault.Enums;

namespace BlazorVault.Utils
{
	// UNDONE: WIP feature idea for handling transitions in components
	public sealed class AnimationStateMachine
	{
		public delegate void SomethingHappened();

		public event SomethingHappened OnEnter;

		private AnimationState _currentState = AnimationState.Idle;

		public AnimationState CurrentState
		{
			get
			{
				return _currentState;
			}
			set
			{
				StateHasChanged();
				_currentState = value;
			}
		}

		public void Enter()
		{
			this.CurrentState = AnimationState.EnterStart;
		}

		private void StateHasChanged()
		{
		}
	}
}

namespace BlazorVault
{
	public enum AnimationState
	{
		Idle = 0,

		EnterStart = 1 << 0,

		EnterEnd = 1 << 1,

		EnterActive = EnterStart | EnterEnd,

		LeaveStart = 1 << 2,

		LeaveEnd = 1 << 3,

		LeaveActive = LeaveStart | LeaveEnd,
	}
}

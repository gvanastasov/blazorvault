namespace BlazorVault
{
	/// <summary>
	/// Default behaviour of the button.
	/// </summary>
	public enum ButtonType
	{
		/// <summary>
		/// The button submits the form data to 
		/// the server. This is the default if 
		/// the attribute is not specified, or 
		/// if the attribute is dynamically 
		/// changed to an empty or invalid value.
		/// </summary>
		Submit,

		/// <summary>
		/// The button resets all the controls 
		/// to their initial values.
		/// </summary>
		Reset,

		/// <summary>
		/// The button has no default behavior 
		/// and does nothing when pressed. It 
		/// can have client-side scripts associated 
		/// with the element's events, which 
		/// are triggered when the events occur.
		/// </summary>
		Button,
	}
}

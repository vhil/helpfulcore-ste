namespace Helpfulcore.Ste.Mvc
{
	public interface IFormViewModel<out TFormData> : IViewModel
		where TFormData : IFormData
	{
		TFormData Form { get; }
	}
}

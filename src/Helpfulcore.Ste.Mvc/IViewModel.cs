namespace Helpfulcore.Ste.Mvc
{
	using Model.Fields.RenderingParameters;
	using Sitecore.Data.Items;

	public interface IViewModel
	{
		Item PageItem { get; }
		Item RenderingItem { get; }
		IRenderingParametersWrapper RenderingParameters { get; }
	}
}

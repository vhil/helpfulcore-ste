namespace Helpfulcore.Ste.Mvc
{
	using System;
	using Model.Fields.RenderingParameters;
	using Sitecore;
	using Sitecore.Data.Items;
	using Sitecore.Mvc.Presentation;
	using Sitecore.Configuration;

	public class ViewModelFactory : IViewModelFactory
	{
		public static IViewModelFactory Instance()
		{
			return Factory.CreateObject("helpfulcore/mvc/viewModelFactory", true) as IViewModelFactory;
		}

		public virtual IViewModel GetViewModel()
		{
			return new ViewModel(
				this.GetPageItem(),
				this.GetRenderingItem(),
				this.GetRenderingParameters());
		}

		public virtual IFormViewModel<TForm> GetViewModel<TForm>() where TForm : IFormData, new()
		{
			var viewModel = this.GetViewModel();
			return new FormViewModel<TForm>(new TForm(), viewModel);
		}

		public virtual IFormViewModel<TForm> GetViewModel<TForm>(TForm form) where TForm : IFormData
		{
			var viewModel = this.GetViewModel();
			return new FormViewModel<TForm>(form, viewModel);
		}

		public virtual Item GetPageItem()
		{
			return PageContext.Current.Item;
		}

		public virtual Item GetRenderingItem()
		{
			Item ret = null;

			// Check for a sitecore query datasource
			var query = RenderingContext.Current.Rendering.DataSource;
			if (query.StartsWith("./", StringComparison.InvariantCulture))
			{
				// Relative to the current context item
				var contextItem = RenderingContext.Current.PageContext.Item;
				if (contextItem != null)
				{
					ret = contextItem.Axes.SelectSingleItem(query);
				}
			}
			else if (!string.IsNullOrEmpty(query))
			{
				// Straight sitecore query
				ret = RenderingContext.Current.ContextItem.Database.SelectSingleItem(query);
			}
			else
			{
				// Item Id set in the datasource
				ret = RenderingContext.Current.Rendering.Item;
			}

			// fallback to page item
			if (ret == null && PageContext.Current.Item != null)
			{

				ret = PageContext.Current.Item;
			}

			return ret ?? Context.Item;
		}

		public virtual IRenderingParametersWrapper GetRenderingParameters()
		{
			var parameters = RenderingContext.Current.Rendering.Parameters;
			return new RenderingParametersWrapper(parameters);
		}
	}
}

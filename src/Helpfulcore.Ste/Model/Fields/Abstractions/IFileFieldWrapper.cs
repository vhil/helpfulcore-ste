namespace Helpfulcore.Ste.Model.Fields.Abstractions
{
    public interface IFileFieldWrapper : IFieldWrapper<string>
    {
	    string DownloadUrl { get; }
	    string Extension { get; }
	    string Size { get; }
	}
}
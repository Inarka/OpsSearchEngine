
namespace OpsSearchEngine.Interfaces
{
	public interface IXmlDeserializer<T> where T : class
	{
		public T Deserialize(string xml);
	}
}

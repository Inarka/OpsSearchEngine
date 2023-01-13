using OpsSearchEngine.Interfaces;
using System.IO;
using System.Xml.Serialization;

namespace OpsSearchEngine.Services
{
	public class XmlFileDeserializer<T> : IXmlDeserializer<T> where T : class
	{
		public T Deserialize(string xml)
		{
			T result;

			XmlSerializer serializer = new XmlSerializer(typeof(T));

			using (StringReader reader = new StringReader(xml))
			{
				result = serializer.Deserialize(reader) as T;
			}

			return result;
		}
	}
}

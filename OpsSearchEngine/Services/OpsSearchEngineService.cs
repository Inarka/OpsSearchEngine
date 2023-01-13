using AutoMapper;
using Microsoft.Extensions.Options;
using OpsSearchEngine.Interfaces;
using OpsSearchEngine.Models;
using OpsSearchEngine.Models.Options;
using OpsSearchEngine.Models.XML;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpsSearchEngine.Services
{
	public class OpsSearchEngineService : IOpsSearchEngine
	{
		private readonly IXmlStringReader _xmlReader;
		private readonly IXmlDeserializer<Project> _xmlDeserializer;
		private readonly ITrie _trie;
		private readonly IMapper _mapper;

		public OpsSearchEngineService(IXmlStringReader xmlReader, IXmlDeserializer<Project> xmlDeserializer, ITrie trie, IMapper mapper)
		{
			_xmlReader = xmlReader;
			_xmlDeserializer = xmlDeserializer;
			_trie = trie;
			_mapper = mapper;
		}

		public async Task<ModulesResponse> FindModules(OpsRequest request)
		{
			var input = await _xmlReader.ReadXmlAsync();

			var project = _xmlDeserializer.Deserialize(input);

			var opsCodesTrieRoot = _trie.Build(project);

			var response = new ModulesResponse();

			foreach (var ops in request.OpsCodes)
			{
				var candidate = _trie.FindNode(opsCodesTrieRoot, ops);

				if (candidate == null)
				{
					continue;
				}

				ChooseCorrectAgeModule(candidate.Modules, request.Age);

				if (CandidateSuits(candidate.Includes, candidate.Excludes, request.OpsCodes))
				{
					var moduleResponse = _mapper.Map<Modul, ModuleResponse>(candidate.Modules.FirstOrDefault());

					moduleResponse.IsEndo = IsEndoOps(ops, candidate.Modules.FirstOrDefault().ENDOOPS);

					response.Modules.Add(ops, moduleResponse);
				}
			}

			return response;
		}

		private bool CandidateSuits(HashSet<string> includes, HashSet<string> excludes, List<string> opsCodes)
		{
			bool suits = false;

			foreach (var ops in opsCodes)
			{
				foreach (var exclude in excludes)
				{
					if (ops.StartsWith(exclude))
					{
						return false;
					}
				}

				if (includes.Count == 0)
				{
					return true;
				}

				foreach (var include in includes)
				{
					if (ops.StartsWith(include))
					{
						suits = true;
						break;
					}
				}

				if (suits)
				{
					break;
				}
			}

			return suits;
		}

		private void ChooseCorrectAgeModule(List<Modul> modules, int age)
		{
			if (modules.Count == 1)
			{
				return;
			}

			if (!modules.Any(x => x.StartAlter != 0 && x.BisAlter != 0))
			{
				return;
			}

			modules = modules.Where(x => x.StartAlter >= age && x.BisAlter <= age).ToList();
		}

		private bool IsEndoOps(string opsCode, string moduleEndoOpses)
		{
			if (moduleEndoOpses == null)
			{
				return false;
			}

			var regexList = moduleEndoOpses.Split(';').Select(x => x.Replace(".", "[.]").Replace("_", @"\S+"));

			foreach (var endoOps in regexList)
			{
				var regex = new Regex(endoOps);

				if (regex.IsMatch(opsCode))
				{
					return true;
				}
			}

			return false;
		}
	}
}

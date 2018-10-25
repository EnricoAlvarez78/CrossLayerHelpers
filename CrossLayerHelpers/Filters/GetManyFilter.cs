using CrossLayerHelpers.Enumerators;
using System.Collections.Generic;

namespace CrossLayerHelpers.Filters
{
	/// <summary>
	/// List Query Object
	/// </summary>
	public class GetManyFilter
	{
		/// <summary>
		/// Filter lister
		/// </summary>
		public IList<Filter> Filter { get; private set; } = new List<Filter>();
		/// <summary>
		/// Fields for ordering
		/// </summary>
		public IDictionary<string, ESortDirection> Sort { get; private set; } = new Dictionary<string, ESortDirection>();

		/// <summary>
		/// Create List Query Object
		/// </summary>
		/// <param name="filter">Filter lister</param>
		/// <param name="sort">Fields for ordering</param>
		public GetManyFilter(IList<Filter> filter, IDictionary<string, ESortDirection> sort)
		{
			Filter = filter;
			Sort = sort;
		}
	}
}

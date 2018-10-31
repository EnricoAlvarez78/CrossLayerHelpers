using CrossLayerHelpers.Enumerators;
using System.Collections.Generic;

namespace CrossLayerHelpers.Filters
{
	/// <summary>
	/// Paged List Query Object
	/// </summary>
	public class GetPaginatedFilter : GetManyFilter
	{
		/// <summary>
		/// Start page
		/// </summary>
		public int? PageIndex { get; private set; } = null;
		/// <summary>
		/// Total Pages
		/// </summary>
		public int? PageSize { get; private set; } = null;

		/// <summary>
		/// Create Paged List Query Object
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <param name="filter"></param>
		/// <param name="sort"></param>
		public GetPaginatedFilter(int? pageIndex, int? pageSize, IList<Filter> filter, IDictionary<string, ESortDirection> sort) : base(filter, sort)
		{
			PageIndex = pageIndex;
			PageSize = pageSize;
		}
	}
}

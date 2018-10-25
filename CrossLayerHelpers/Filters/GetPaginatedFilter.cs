namespace CrossLayerHelpers.Filters
{
	/// <summary>
	/// Paged List Query Object
	/// </summary>
	public class GetPaginatedFilter
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
		public GetPaginatedFilter(int? pageIndex, int? pageSize)
		{
			PageIndex = pageIndex;
			PageSize = pageSize;
		}
	}
}

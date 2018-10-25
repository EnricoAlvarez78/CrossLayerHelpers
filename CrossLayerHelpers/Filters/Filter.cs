using CrossLayerHelpers.Enumerators;

namespace CrossLayerHelpers.Filters
{
	/// <summary>
	/// Query Filter
	/// </summary>
	public class Filter
	{
		/// <summary>
		/// Field filter
		/// </summary>
		public string Field { get; private set; }
		/// <summary>
		/// Filter value
		/// </summary>
		public string Value { get; private set; }
		/// <summary>
		/// Comparison operator
		/// </summary>
		public ECompareOperator CompareOperator { get; private set; }
		/// <summary>
		/// Logical operator
		/// </summary>
		public ELogicOperator LogicOperator { get; private set; }

		/// <summary>
		/// Create Query Filter
		/// </summary>
		/// <param name="field">Field filter</param>
		/// <param name="value">Filter value</param>
		/// <param name="compareOperator">Comparison operator. Null case, the default operator EQUALS will be defined.</param>
		/// <param name="logicOperator">Logical operator. Null case, the standard AND operator will be defined.</param>
		public Filter(string field, string value, ECompareOperator? compareOperator = null, ELogicOperator? logicOperator = null)
		{
			Field = field;
			Value = value;
			CompareOperator = compareOperator == null ? ECompareOperator.Equals : compareOperator.Value;
			LogicOperator = logicOperator == null ? ELogicOperator.And : logicOperator.Value;
		}
	}
}

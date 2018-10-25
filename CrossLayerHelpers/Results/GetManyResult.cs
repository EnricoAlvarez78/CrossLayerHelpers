using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CrossLayerHelpers.Results
{
	public class GetManyResult<TEntity> : OperationResult where TEntity : class
	{
		/// <summary>
		/// Total entities
		/// </summary>
		public long TotalAmount { get; private set; } = 0;
		/// <summary>
		/// List entities
		/// </summary>
		public IEnumerable<TEntity> Entities { get; private set; } = null;

		/// <summary>
		/// Creates specialized response object with many entities
		/// </summary>
		/// <param name="entities">List entities</param>
		/// <param name="totalAmount">Total entities</param>
		/// <param name="success"></param>
		/// <param name="message"></param>
		/// <param name="statusCode"></param>
		/// <param name="exception"></param>
		public GetManyResult(IEnumerable<TEntity> entities, long totalAmount, bool success, string message, HttpStatusCode statusCode, Exception exception) : base(success, message, statusCode, exception)
		{
			Entities = entities;
			TotalAmount = totalAmount;
		}

		/// <summary>
		/// Validate response success
		/// </summary>
		/// <param name="manyResult"></param>
		/// <returns></returns>
		public static bool WasSuccessful(GetManyResult<TEntity> manyResult) => manyResult != null && manyResult.Success && manyResult.Entities != null && manyResult.TotalAmount >= 0 ? true : false;

		/// <summary>
		/// Creates a successful response object with many entities
		/// </summary>
		/// <param name="entities"></param>
		/// <param name="totalAmount"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static GetManyResult<TEntity> SuccessResponse(IEnumerable<TEntity> entities, long? totalAmount = null, string message = null) => new GetManyResult<TEntity>(entities, totalAmount ?? entities.Count(), true, string.IsNullOrEmpty(message) ? HttpStatusCode.OK.ToString() : message, HttpStatusCode.OK, null);

		/// <summary>
		/// Creates failover response object with many entities
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public new static GetManyResult<TEntity> BadRequestResponse(string message = null) => new GetManyResult<TEntity>(null, 0, false, string.IsNullOrEmpty(message) ? HttpStatusCode.BadRequest.ToString() : message, HttpStatusCode.BadRequest, null);

		/// <summary>
		/// Creates an error response object with many entities
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public new static GetManyResult<TEntity> ErrorResponse(string message = null) => new GetManyResult<TEntity>(null, 0, false, string.IsNullOrEmpty(message) ? HttpStatusCode.InternalServerError.ToString() : message, HttpStatusCode.InternalServerError, null);

		/// <summary>
		/// Creates response object with exception with many entities
		/// </summary>
		/// <param name="ex"></param>
		/// <returns></returns>
		public new static GetManyResult<TEntity> ExceptionResponse(Exception ex) => new GetManyResult<TEntity>(null, 0, false, ex.Message, HttpStatusCode.InternalServerError, ex);

		/// <summary>
		/// Concat results
		/// </summary>
		/// <param name="dadosEnvioList"></param>
		/// <param name="totalAmount"></param>
		public void ConcatResults(IEnumerable<TEntity> dadosEnvioList, long totalAmount)
		{
			var list = Entities.ToList();
			list.AddRange(dadosEnvioList);

			Entities = list as IEnumerable<TEntity>;
			TotalAmount = TotalAmount + totalAmount;
		}
	}
}

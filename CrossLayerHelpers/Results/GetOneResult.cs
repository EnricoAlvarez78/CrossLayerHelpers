using System;
using System.Net;

namespace CrossLayerHelpers.Results
{
	public class GetOneResult<TEntity> : OperationResult where TEntity : class
	{
		public TEntity Entity { get; private set; }
		/// <summary>
		/// Creates specialized response object with an entity
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="success"></param>
		/// <param name="message"></param>
		/// <param name="statusCode"></param>
		/// <param name="exception"></param>
		public GetOneResult(TEntity entity, bool success, string message, HttpStatusCode statusCode, Exception exception) : base(success, message, statusCode, exception) => Entity = entity;

		/// <summary>
		/// Validate response success
		/// </summary>
		/// <param name="oneResult"></param>
		/// <returns></returns>
		public static bool WasSuccessful(GetOneResult<TEntity> oneResult) => oneResult != null && oneResult.Success && oneResult.Entity != null ? true : false;

		/// <summary>
		/// Creates object of successful response with an entity
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static GetOneResult<TEntity> SuccessResponse(TEntity entity, string message = null) => new GetOneResult<TEntity>(entity, true, string.IsNullOrEmpty(message) ? HttpStatusCode.OK.ToString() : message, HttpStatusCode.OK, null);

		/// <summary>
		/// Create failed response object with an entity
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public new static GetOneResult<TEntity> BadRequestResponse(string message = null) => new GetOneResult<TEntity>(null, false, string.IsNullOrEmpty(message) ? HttpStatusCode.BadRequest.ToString() : message, HttpStatusCode.BadRequest, null);

		/// <summary>
		/// Creates an error response object with an entity
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public new static GetOneResult<TEntity> ErrorResponse(string message = null) => new GetOneResult<TEntity>(null, false, string.IsNullOrEmpty(message) ? HttpStatusCode.InternalServerError.ToString() : message, HttpStatusCode.InternalServerError, null);

		/// <summary>
		/// Creates response object with exception with an entity
		/// </summary>
		/// <param name="ex"></param>
		/// <returns></returns>
		public new static GetOneResult<TEntity> ExceptionResponse(Exception ex) => new GetOneResult<TEntity>(null, false, ex.Message, HttpStatusCode.InternalServerError, ex);
	}
}

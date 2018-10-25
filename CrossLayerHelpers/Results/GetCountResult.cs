using System;
using System.Net;

namespace CrossLayerHelpers.Results
{
	public class GetCountResult : OperationResult
	{
		/// <summary>
		/// Total count
		/// </summary>
		public long? Amount { get; private set; }

		/// <summary>
		/// Creates specialized counting object 
		/// </summary>
		/// <param name="amount"></param>
		/// <param name="success"></param>
		/// <param name="message"></param>
		/// <param name="statusCode"></param>
		/// <param name="exception"></param>
		public GetCountResult(long? amount, bool success, string message, HttpStatusCode statusCode, Exception exception) : base(success, message, statusCode, exception) => Amount = amount;

		/// <summary>
		/// Valid counts successful
		/// </summary>
		/// <param name="Amount"></param>
		/// <returns></returns>
		public static bool WasSuccessful(long? Amount) => Amount != null && Amount >= 0 ? true : false;

		/// <summary>
		/// Creates counting object successfully
		/// </summary>
		/// <param name="amount"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static GetCountResult SuccessResponse(long amount, string message = null) => new GetCountResult(amount, true, string.IsNullOrEmpty(message) ? HttpStatusCode.OK.ToString() : message, HttpStatusCode.OK, null);

		/// <summary>
		/// Creates failed count object
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public new static GetCountResult BadRequestResponse(string message = null) => new GetCountResult(null, false, string.IsNullOrEmpty(message) ? HttpStatusCode.BadRequest.ToString() : message, HttpStatusCode.BadRequest, null);

		/// <summary>
		/// Creates object of count with error
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public new static GetCountResult ErrorResponse(string message = null) => new GetCountResult(null, false, string.IsNullOrEmpty(message) ? HttpStatusCode.InternalServerError.ToString() : message, HttpStatusCode.InternalServerError, null);

		/// <summary>
		/// Creates count object with exception
		/// </summary>
		/// <param name="ex"></param>
		/// <returns></returns>
		public new static GetCountResult ExceptionResponse(Exception ex) => new GetCountResult(null, false, ex.Message, HttpStatusCode.InternalServerError, ex);
	}
}

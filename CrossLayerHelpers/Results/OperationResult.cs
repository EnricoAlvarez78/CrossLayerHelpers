using System;
using System.Net;

namespace CrossLayerHelpers.Results
{
	public class OperationResult
	{
		public bool Success { get; private set; }
		public string Message { get; private set; }
		public HttpStatusCode StatusCode { get; private set; }
		public Exception Exception { get; private set; }

		/// <summary>
		/// Creates specialized response object
		/// </summary>
		/// <param name="success"></param>
		/// <param name="message"></param>
		/// <param name="statusCode"></param>
		/// <param name="exception"></param>
		public OperationResult(bool success, string message, HttpStatusCode statusCode, Exception exception)
		{
			Success = success;
			Message = message;
			StatusCode = statusCode;
			Exception = exception;
		}

		/// <summary>
		/// Validate response success
		/// </summary>
		/// <param name="operationResult"></param>
		/// <returns></returns>
		public static bool WasSuccessful(OperationResult operationResult) => operationResult != null && operationResult.Success ? true : false;

		/// <summary>
		/// Create successful response object
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public static OperationResult SuccessResponse(string message = null) => new OperationResult(true, string.IsNullOrEmpty(message) ? HttpStatusCode.OK.ToString() : message, HttpStatusCode.OK, null);

		/// <summary>
		/// Create failed response object
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public static OperationResult BadRequestResponse(string message = null) => new OperationResult(false, string.IsNullOrEmpty(message) ? HttpStatusCode.BadRequest.ToString() : message, HttpStatusCode.BadRequest, null);

		/// <summary>
		/// Create response object with error
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public static OperationResult ErrorResponse(string message = null) => new OperationResult(false, string.IsNullOrEmpty(message) ? HttpStatusCode.InternalServerError.ToString() : message, HttpStatusCode.InternalServerError, null);

		/// <summary>
		/// Cria objeto de resposta com exceção
		/// </summary>
		/// <param name="ex"></param>
		/// <returns></returns>
		public static OperationResult ExceptionResponse(Exception ex) => new OperationResult(false, ex.Message, HttpStatusCode.InternalServerError, ex);
	}
}

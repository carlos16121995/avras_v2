using avras_v2.Domain.Infrastructures.Exceptions;
using System.Runtime.CompilerServices;

namespace avras_v2.Domain.Infrastructures.Responses
{
    public static class BaseResponseExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MontarErro<T>(this BaseResponse<T> response, Exception ex, string genericMessage = "Ocorreu um erro inesperado ao processar a sua solicitação. Verifique os dados e tente novamente.")
        {
            response.Success = false;
            response.Data = default;
            if (ex is AvrasException)
            {
                AvrasException ex2 = ex as AvrasException ?? new();
                response.StatusCode = ex2.CodResponse;
                response.Message = ex2.Message;
                response.ErrorDetails = ex2.InnerException?.Message ?? string.Empty;
            }
            else
            {
                response.Message = genericMessage;
                response.ErrorDetails = ex.Message;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MontarErro<T>(this BaseResponse<T> response, IEnumerable<ErrorModel> Errors) where T : class
        {
            response.Success = false;
            response.Errors = Errors;
            response.Data = null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MontarErro<T>(this BasePagedResponse<T> response, Exception ex, string genericMessage = "Ocorreu um erro inesperado ao processar a sua solicitação. Verifique os dados e tente novamente.")
        {
            response.Success = false;
            response.Data = null;
            if (ex is AvrasException)
            {
                AvrasException ex2 = ex as AvrasException ?? new();
                response.StatusCode = ex2.CodResponse;
                response.Message = ex2.Message;
                response.ErrorDetails = ex2.InnerException?.Message ?? string.Empty;
            }
            else
            {
                response.Message = genericMessage;
                response.ErrorDetails = ex.Message;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MontarErro<T>(this BasePagedResponse<T> response, IEnumerable<ErrorModel> Errors) where T : class
        {
            response.Success = false;
            response.Errors = Errors;
            response.Data = null;
        }
    }
}

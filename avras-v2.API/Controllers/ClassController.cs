using avras_v2.Application.Class;
using avras_v2.Domain.Infrastructures.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace avras_v2.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/class")]
    [AllowAnonymous]
    public class ClassController : BaseController
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ClassController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        /// <summary>
        /// Endpoint para inserir usuários
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesDefaultResponseType(typeof(BaseResponse<string>))]
        public async Task<IActionResult> Insert(ClassCommand request)
        {
            var response = new BaseResponse<string>();
            try
            {
                await _mediator.Send(request);
                response.Success = true;
                response.Message = "";
            }
            catch (Exception ex)
            { response.MontarErro(ex); }

            return Result(response);
        }
    }
}

using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avras_v2.Application.Class
{
    public class ClassCommandHandler : IRequestHandler<ClassCommand>
    {
        public ClassCommandHandler()
        {
        }

        public async Task<Unit> Handle(ClassCommand request, CancellationToken cancellationToken)
        {
			throw new NotImplementedException();
        }
    }
}

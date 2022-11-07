using Base;
using Types;

namespace Orchestration
{
    public class TransactionManager :OrchestrationBase<IContract>
    {
        public GenericResponse<IContract> Get(IContract entity)
        {
            GenericResponse<IContract> response = new GenericResponse<IContract>();
            BusinessModel<IContract> businessModel;
            return response;
        }
    }
}

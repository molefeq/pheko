using Pheko.Common.Enums;

using Pheko.WebPresentation.Utility;

namespace Pheko.WebPresentation.MappingViewModelsToDtos
{
    public class CrudOperationsMapper
    {
        public CrudOperationsMapper() { }

        public CrudOperations MapToCrudOperations(ModelCrudOperations modelCrudOperations)
        {
            switch (modelCrudOperations)
            {
                case ModelCrudOperations.Delete:
                    return CrudOperations.Delete;
                case ModelCrudOperations.Update:
                    return CrudOperations.Update;
                default:
                    return CrudOperations.Create;
            }
        }

        public ModelCrudOperations MapToModelCrudOperations(CrudOperations crudOperations)
        {
            switch (crudOperations)
            {
                case CrudOperations.Delete:
                    return ModelCrudOperations.Delete;
                case CrudOperations.Update:
                    return ModelCrudOperations.Update;
                default:
                    return ModelCrudOperations.Create;
            }
        }

    }
}

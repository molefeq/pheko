using System;
using System.Collections.Generic;

namespace Pheko.WebPresentation.Utility
{
    public class ModelException : Exception
    {
        public List<ModelError> ModelErrors { get; set; }

        public ModelException()
            : base()
        {
            ModelErrors = new List<ModelError>();
        }

        public ModelException(string strBindError)
            : base(strBindError)
        {
            ModelErrors = new List<ModelError>();
        }
    }
}

using System;

namespace HttpServer.Mvc.Controllers
{
    /// <summary>
    /// Action is valid for specific HTTP methods.
    /// </summary>
    internal class ValidForAttribute : Attribute
    {
        public ValidForAttribute(params string[] methods)
        {
            for (int i = 0; i < methods.Length; i++)
                methods[i] = methods[i].ToUpper();
            Methods = methods;
        }

        /// <summary>
        /// Methods that this action is valid for.
        /// </summary>
        public string[] Methods { get; private set; }
    }
}
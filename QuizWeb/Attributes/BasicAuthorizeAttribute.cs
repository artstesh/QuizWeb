using System;
using Microsoft.AspNetCore.Mvc;

namespace QuizApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BasicAuthorizeAttribute : TypeFilterAttribute
    {
        public BasicAuthorizeAttribute()
            : base(typeof(BasicAuthorizeFilter))
        {
        }
    }
}
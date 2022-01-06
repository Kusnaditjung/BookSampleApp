using Microsoft.AspNetCore.Mvc.Filters;

namespace Book.Api.Filters
{
	public class ResFilter : IResultFilter
	{
		public void OnResultExecuted(ResultExecutedContext context)
		{
			//context.HttpContext.Response.Headers.Add("test", "111");
		}

		public void OnResultExecuting(ResultExecutingContext context)
		{
			context.HttpContext.Response.Headers.Add("test", "111");
		}
	}
}

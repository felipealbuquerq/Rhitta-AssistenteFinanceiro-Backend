using Microsoft.AspNetCore.Builder;

namespace AssistenteFinanceiro.Api.Configurations
{
    public static class Http2ResponseConfiguration
    {
        public static void ConfigureHttp2Response(this IApplicationBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });
        }
    }
}

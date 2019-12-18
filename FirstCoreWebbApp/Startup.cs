using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FirstCoreWebbApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();   //add MVC så att du kan använda MVC strukturen, lägg till servicen MVC
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            //lägger till middelware som går igenom går till routing - kollas om blockas skickas till den tillbaka...
            //om ok går den ner till aktuellt  middlevare.program som jacks/körs

            //app.UseDefaultFiles(); //"jag skall leta efter"    lagt till denna - som letar efter defaultfilerna index.html eller default.html - men var finns filerna? vi vet inte, kommer inte åt dem
            app.UseStaticFiles(); //"ååå där ligger den ju"    default opens up the wwwroot folder to be accesed -    denna öppna upp - används nu som en statisk server
            //man öppnar alltså upp det man behöver succesivt

            app.UseRouting(); //"här vet jag vad jag skall göra för respons"     denna skall ligga efter 
            //hittar vi filen Wooow - vi kör den och kommer då aldrig ner i Endpoint=defultläge


            //app.UseMvcWithDefaultRoute(); //sätter MVC default. 


            //om man ser "hello word" då har man fått default... man har fuckat upp 

            app.UseEndpoints(endpoints =>
            {
                //special routes before default
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");  //denna raden aktiverar htmlsidan vi skall ha katalog HOME och  dess INDEX
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}

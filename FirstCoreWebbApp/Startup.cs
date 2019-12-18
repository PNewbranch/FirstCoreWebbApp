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
            services.AddMvc();   //add MVC s� att du kan anv�nda MVC strukturen, l�gg till servicen MVC
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            //l�gger till middelware som g�r igenom g�r till routing - kollas om blockas skickas till den tillbaka...
            //om ok g�r den ner till aktuellt  middlevare.program som jacks/k�rs

            //app.UseDefaultFiles(); //"jag skall leta efter"    lagt till denna - som letar efter defaultfilerna index.html eller default.html - men var finns filerna? vi vet inte, kommer inte �t dem
            app.UseStaticFiles(); //"��� d�r ligger den ju"    default opens up the wwwroot folder to be accesed -    denna �ppna upp - anv�nds nu som en statisk server
            //man �ppnar allts� upp det man beh�ver succesivt

            app.UseRouting(); //"h�r vet jag vad jag skall g�ra f�r respons"     denna skall ligga efter 
            //hittar vi filen Wooow - vi k�r den och kommer d� aldrig ner i Endpoint=defultl�ge


            //app.UseMvcWithDefaultRoute(); //s�tter MVC default. 


            //om man ser "hello word" d� har man f�tt default... man har fuckat upp 

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

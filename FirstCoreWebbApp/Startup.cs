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





            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(10); //här har vi 10 minuter session för coocies 
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });





            services.AddMvc();   //add MVC så att du kan använda MVC strukturen, lägg till servicen MVC
            //services.AddControllersWithViews();  räcker ofta vid begränsad funktionalitet - vid api servar etc skal man hellre använda MVC (raden ovan)
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
            //skall vara 4 st här, UseSession UseHttpContextItemsMiddleware tillhör kod i ***

            //app.UseDefaultFiles(); //"jag skall leta efter"    lagt till denna - som letar efter defaultfilerna index.html eller default.html - men var finns filerna? vi vet inte, kommer inte åt dem
            app.UseStaticFiles(); //"ååå där ligger den ju"    default opens up the wwwroot folder to be accesed -    denna öppna upp - används nu som en statisk server
            //man öppnar alltså upp det man behöver succesivt

            //***
            app.UseSession();
                                          
            app.UseRouting(); //"här vet jag vad jag skall göra för respons"     denna skall ligga efter 
            //hittar vi filen Wooow - vi kör den och kommer då aldrig ner i Endpoint=defultläge

            //*** här fungerar det inte då detta är 2:ans kod - för att göra den framtidsäker för att lägga till mer funktionalitet i framtiden
            //app.UseHttpContextItemsMiddleware(); 




            //app.UseMvcWithDefaultRoute(); //sätter MVC default. 


            //om man ser "hello word" då har man fått default... man har fuckat upp 

            app.UseEndpoints(endpoints =>
            {

                //ses som ifsatser, den som matchars körs, default läggs sist

                //får pattern värdet i url
                //SPECIALROUTS -specialrouting se uppgift 2 -  kan bla ändra URL:s hur den ser ut med dessa specialrutter
                endpoints.MapControllerRoute(                           //name pattern default är otional, kan i och för sig användas för att skifta ordningen - DU KAN ÄNDRA ORDNINGEN PÅ ALLA METODER I SAMBAND MED ATT DU ANROPAR DEM
                    name: "ReviewRoute",                                       //name of route rule
                    pattern: "TheReviews",                                          //Url to mach
                    defaults: new { controller = "ReadViews", action = "Index" }     //what controller och action to call  NOTERA ATT JAG HAR READ inte RE views
                    );

                //får pattern värdet i url
                //SPECIALROUTS - en till "att skapa en review"
                endpoints.MapControllerRoute(                           //name pattern default är otional, kan i och för sig användas för att skifta ordningen - DU KAN ÄNDRA ORDNINGEN PÅ ALLA METODER I SAMBAND MED ATT DU ANROPAR DEM
                    name: "CreateReviewRoute",                                       //name of route rule
                    pattern: "WriteYourReviews",                                          //Url to mach
                    defaults: new { controller = "ReadViews", action = "Create" }     //what controller och action to call  NOTERA ATT JAG HAR READ inte RE views
                    );



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

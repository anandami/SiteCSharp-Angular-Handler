using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Http.Cors;

[EnableCors("*", "*", "*", "*")]
public class HandlerBook : IHttpHandler {
    

    public void ProcessRequest(HttpContext context)
    {
        string methodname = string.Empty;
        methodname = context.Request.Params["method"];

        if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
        {
            context.Response.StatusCode = 200;
            context.Response.End();
            
            context.Response.ContentType = "application/json";
            context.Response.AddHeader("Access-Control-Allow-Methods", "*");
            context.Response.AddHeader("Access-Control-Allow-Headers", "*");
            context.Response.AddHeader("Access-Control-Allow‌​-Credentials", "true");
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-ExposedHeaders", "*");
            


        }

        

        string id = context.Request.QueryString["id"];

        

        switch (methodname.ToLower())

        {

            case "getall":

                context.Response.Write(GetAll());

                break;

            case "getbyid":

                context.Response.Write(GetById(Convert.ToInt32(id)));

                break;

            case "post":

                context.Response.Write(Post(context));

                break;

            case "update":

                context.Response.Write(Update(context, Convert.ToInt32(id)));

                break;

            case "delete":

                context.Response.Write(Delete(Convert.ToInt32(id)));

                break;

        }


    }

    public string GetAll()
    {
        string response = "";
        BookModel book = new BookModel();
        response = JsonConvert.SerializeObject(book.GetAllData(), Formatting.Indented);

        return response;
    }

    public string Post(HttpContext context)
    {
        System.IO.StreamReader reader = new System.IO.StreamReader(System.Web.HttpContext.Current.Request.InputStream);

        var requestFromPost = reader.ReadToEndAsync();

        string teste = requestFromPost.Result;

        BookModel books = JsonConvert.DeserializeObject<BookModel>(teste);

        books.Insert(books);

        return teste;
    }

    public string GetById(int id)
    {
        string response = "";
        BookModel book = new BookModel();
        response = JsonConvert.SerializeObject(book.Search(id), Formatting.Indented);

        return response;
    }

    public string Update(HttpContext context, int id)
    {
        System.IO.StreamReader reader = new System.IO.StreamReader(System.Web.HttpContext.Current.Request.InputStream);

        var requestFromPost = reader.ReadToEndAsync();

        string response = requestFromPost.Result;

        BookModel books = JsonConvert.DeserializeObject<BookModel>(response);

        books.Update(books, id);

        return response;
    }

    public string Delete(int id)
    {
        string response = "Registro deletado com sucesso";

        BookModel book = new BookModel();

        book.Delete(id);
       
        return response;
    }




    public bool IsReusable {
        get {
            return false;
        }
    }

    

}
 
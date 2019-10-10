using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

 
[EnableCors("*", "*", "*", "*")]
public class BookModel
{
    //atributos
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Release { get; set; }
    public string PublishingHouse { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }

    //construtores
    public BookModel(){
    }

    public BookModel(int id, string title, string author, int release, string publishingHouse, string category, string description){
        Id = id;
        Title = title;
        Author = author;
        Release = release;
        PublishingHouse = publishingHouse;
        Category = category;
        Description = description;
    }

    //MÉTODOS CRUD
    public List<BookModel> GetAllData()
    {

        //abrindo o canal com o banco
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5434;User Id=postgres;Password=admin;Database=challange;");
        conn.Open();

        NpgsqlCommand exibeAll = new NpgsqlCommand("select * from book order by id asc", conn);

        List<BookModel> booklist = new List<BookModel>();
        //buscando dados
        try
        {
            NpgsqlDataReader dt = exibeAll.ExecuteReader();
            while (dt.Read())
            {
                BookModel book = new BookModel();
                book.Id = (int)dt["id"];
                book.Title = (string)dt["title"];
                book.Author = (string)dt["author"];
                book.Release = (int)dt["release"];
                book.PublishingHouse = (string)dt["publishing"];
                book.Category = (string)dt["category"];
                book.Description = (string)dt["description"];

                booklist.Add(book);

            }
            Console.Write(booklist);
        }
        catch (Exception ex)
        {
            string teste = ex.Message;
        }

        finally
        {
            conn.Close();
        }

        return booklist;

    }

    //métodos CRUD - inserir dado no banco de dados 
    public void Insert(BookModel books)
    {
        BookModel book = new BookModel();

        book = books;
        //abrindo o canal com o banco
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5434;User Id=postgres;Password=admin;Database=challange;");
        conn.Open();

        try
        {
            //gerando o comando com o banco
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO BOOK (TITLE,AUTHOR,RELEASE,PUBLISHING,CATEGORY,DESCRIPTION) VALUES(@title,@author,@release,@publishing,@category,@description); ";
            cmd.Parameters.AddWithValue("@title", book.Title);
            cmd.Parameters.AddWithValue("@author", book.Author);
            cmd.Parameters.AddWithValue("@release", book.Release);
            cmd.Parameters.AddWithValue("@publishing", book.PublishingHouse);
            cmd.Parameters.AddWithValue("@category", book.Category);
            cmd.Parameters.AddWithValue("@description", book.Description);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
                Console.WriteLine("Registro realizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.ToString());
        }
        finally
        {
            conn.Close();
        }
        
    }


    //métodos CRUD - ler um dado no banco
    public List<BookModel> Search(int id)
    {
        //abrindo o canal com o banco e fazendo a busca
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5434;User Id=postgres;Password=admin;Database=challange;");
        NpgsqlCommand cmd = new NpgsqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM BOOK WHERE ID='" + id + "';";
        cmd.CommandType = CommandType.Text;

        conn.Open();

        List<BookModel> book = new List<BookModel>(id);

        try
        {
            NpgsqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                BookModel book1 = new BookModel();
                book1.Id = (int)data["id"];
                book1.Title = (string)data["title"];
                book1.Author = (string)data["author"];
                book1.Release = (int)data["release"];
                book1.PublishingHouse = (string)data["publishing"];
                book1.Category = (string)data["category"];
                book1.Description = (string)data["description"];
                book.Add(book1);
            }
        }
        finally
        {
            conn.Close();
        }
        return book;
    }

    //métodos CRUD - atualizar todos os campos de uma só vez
    public void Update(BookModel books, int id)
    {
        BookModel book = new BookModel();

        book = books;
        //abrindo o canal com o banco
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5434;User Id=postgres;Password=admin;Database=challange;");

        //buscando o dado a partir da ID 
        NpgsqlCommand cmd = new NpgsqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "UPDATE BOOK SET TITLE=@title,AUTHOR=@author,RELEASE=@release,PUBLISHING=@publishing,CATEGORY=@category,DESCRIPTION=@description WHERE ID='" + id + "';";
        cmd.Parameters.AddWithValue("@title", book.Title);
        cmd.Parameters.AddWithValue("@author", book.Author);
        cmd.Parameters.AddWithValue("@release", book.Release);
        cmd.Parameters.AddWithValue("@publishing", book.PublishingHouse);
        cmd.Parameters.AddWithValue("@category", book.Category);
        cmd.Parameters.AddWithValue("@description", book.Description);
        cmd.CommandType = CommandType.Text;

        conn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
                Console.WriteLine("Cadastro atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.ToString());
        }
        finally
        {
            conn.Close();
        }
    }


    //deletar um registro
    public void Delete(int id)
    {
        //abrindo o canal com o banco
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5434;User Id=postgres;Password=admin;Database=challange;");

        //buscando o dado a partir da ID 
        NpgsqlCommand cmd = new NpgsqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "DELETE FROM BOOK WHERE ID='" + id + "';";
        cmd.CommandType = CommandType.Text;

        conn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
                Console.WriteLine("Registro deletado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.ToString());
        }
        finally
        {
            conn.Close();
        }
    }

}
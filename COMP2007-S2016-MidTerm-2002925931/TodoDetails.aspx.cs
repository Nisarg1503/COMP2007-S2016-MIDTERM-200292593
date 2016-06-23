using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// required for EF DB
using COMP2007_S2016_MidTerm_2002925931.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

// File   : TodoList.aspx
// Author : Nisarg Patel
// Website: http://comp2007-s2016-midterm-200292593.azurewebsites.net/
// Description:  This page contains methods which can run add or edit with DB and checkbox


namespace COMP2007_S2016_MidTerm_2002925931
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetTodo();
            }
        }

       
        protected void GetTodo()
        {
            // populate the form with existing data from the database
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            // connect to the EF DB
            using (TodoConnection db = new TodoConnection())
            {
                // populate a todo object instance with the TodoID from the URL Parameter
                Todo updatedTodo = (from todo in db.Todos
                                    where todo.TodoID == TodoID
                                    select todo).FirstOrDefault();

                // map the todo properties to the form controls
                if (updatedTodo != null)
                {
                    TodoNameTextBox.Text = updatedTodo.TodoName;
                    TodoNotesTextBox.Text = updatedTodo.TodoNotes;
                    //Checkbox request
                    if (updatedTodo.Completed == true)
                    {
                        CompletedCheckBox.Checked = true;
                    }
                    else
                    {
                        CompletedCheckBox.Checked = false;
                    }

                }
            }
        }
        
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to Todo list page
            Response.Redirect("~/TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the server
            using (TodoConnection db = new TodoConnection())
            {
                // use the Todo model to create a new student object and save a new record
                Todo newTodo = new Todo();

                int TodoID = 0;

                if (Request.QueryString.Count > 0)
                {
                    // get the id from url
                    TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    // get the current todo from EF DB
                    newTodo = (from todo in db.Todos
                               where todo.TodoID == TodoID
                               select todo).FirstOrDefault();
                }

                // add form data to the new Todo record
                newTodo.TodoName = TodoNameTextBox.Text;
                newTodo.TodoNotes = TodoNotesTextBox.Text;
                newTodo.Completed = CompletedCheckBox.Checked;
                // use LINQ to ADO.NET to add / insert new todo into the database
                if (TodoID == 0)
                {
                    db.Todos.Add(newTodo);
                }

                // save our changes
                db.SaveChanges();

                // Redirect back to the updated todos page
                Response.Redirect("~/TodoList.aspx");
            }
        }
    }
}
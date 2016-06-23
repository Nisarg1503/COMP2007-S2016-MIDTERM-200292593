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

        /**
       * <summary>
       * This method gets a todos data from the DB
       * </summary>
       * 
       * @method GetTodo
       * @returns {void}
       */
        protected void GetTodo()
        {
            // populate the form with todo data if exists
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            // connect to the EF DB
            using (TodoConnection db = new TodoConnection())
            {
                Todo updatedTodo = (from todo in db.Todos
                                    where todo.TodoID == TodoID
                                    select todo).FirstOrDefault();

                //fill form if todo exists
                if (updatedTodo != null)
                {
                    TodoNameTextBox.Text = updatedTodo.TodoName;
                    TodoNotesTextBox.Text = updatedTodo.TodoNotes;
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
                // save a new record
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

                // add todo to form
                newTodo.TodoName = TodoNameTextBox.Text;
                newTodo.TodoNotes = TodoNotesTextBox.Text;
                newTodo.Completed = CompletedCheckBox.Checked;
                // use LINQ to ADO.NET to add / insert new todo into the database

                // check to see if a new todo is being added
                if (TodoID == 0)
                {
                    db.Todos.Add(newTodo);
                }

                // save our changes - run an update
                db.SaveChanges();

                // Redirect back to the updated todos page
                Response.Redirect("~/TodoList.aspx");
            }
        }
    }
}
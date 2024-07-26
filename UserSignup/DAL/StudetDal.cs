using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using UserSignup.Models;
namespace UserSignup.DAL
{
    public class StudetDal
    {

        string conString = ConfigurationManager.ConnectionStrings["mycrudconnectionstring"].ToString();


        //Create student

        public bool InsertStudent(Student student)
        {

            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_InsertStudentsData", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);

                command.Parameters.AddWithValue("@Phone", student.Phone);
                command.Parameters.AddWithValue("@Address", student.Address);
                command.Parameters.AddWithValue("@Gender", student.Gender);
                command.Parameters.AddWithValue("@Dob", student.Dob);
                command.Parameters.AddWithValue("@City", student.City);
                command.Parameters.AddWithValue("@State", student.State);
                command.Parameters.AddWithValue("@pin", student.Pin);


                if (student.ImageData != null)
                {
                    command.Parameters.Add("@ImageData", SqlDbType.VarBinary, -1).Value = student.ImageData;
                }
                else
                {
                    command.Parameters.Add("@ImageData", SqlDbType.VarBinary, -1).Value = DBNull.Value;
                }


                if (student.PdfData != null)
                {
                    command.Parameters.Add("@pdfData", SqlDbType.VarBinary, -1).Value = student.PdfData;
                }
                else
                {
                    command.Parameters.Add("@pdfData", SqlDbType.VarBinary, -1).Value = DBNull.Value;
                }

                command.Parameters.AddWithValue("@Email", student.Email);


                connection.Open();
                id = command.ExecuteNonQuery();
                connection.Close();

            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }






    }
}
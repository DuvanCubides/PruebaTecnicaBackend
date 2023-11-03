using Backend.Model;
using System.Data.SqlClient;

namespace Backend.Data
{
    public class StudentData
    {
        public static bool Create(StudentModel ostudent)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Insert into Students(name,last_name,address,cellphone,email,descripcion,idNote) VALUES(@name,@last_name,@address,@cellphone,@email,@description,@idNote)", oConexion);
                cmd.Parameters.AddWithValue("@name", ostudent.name);
                cmd.Parameters.AddWithValue("@last_name", ostudent.last_name);
                cmd.Parameters.AddWithValue("@address", ostudent.address);
                cmd.Parameters.AddWithValue("@cellphone", ostudent.cellphone);
                cmd.Parameters.AddWithValue("@email", ostudent.email);
                cmd.Parameters.AddWithValue("@description", ostudent.descripcion);
                cmd.Parameters.AddWithValue("@idNote", ostudent.idNote);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool Update(StudentModel ostudent,int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Update Students Set name = @name ,last_name = @last_name, address =@address,cellphone =@cellphone,email=@email,descripcion=@description,idNote=@idNote WHERE id = @id",oConexion);
                cmd.Parameters.AddWithValue("@name", ostudent.name);
                cmd.Parameters.AddWithValue("@last_name", ostudent.last_name);
                cmd.Parameters.AddWithValue("@address", ostudent.address);
                cmd.Parameters.AddWithValue("@cellphone", ostudent.cellphone);
                cmd.Parameters.AddWithValue("@email", ostudent.email);
                cmd.Parameters.AddWithValue("@description", ostudent.descripcion);
                cmd.Parameters.AddWithValue("@idNote", ostudent.idNote);
                cmd.Parameters.AddWithValue("@id", id);


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }
        public static bool Delete(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Delete from Students where id = @id", oConexion);
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static List<StudentModel> GetStudents()
        {
            List<StudentModel> oStudent = new List<StudentModel>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Select * from Students",oConexion);
                oConexion.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while(rd.Read())
                    {
                        oStudent.Add(new StudentModel()
                        {
                            id = Convert.ToInt32(rd["id"]),
                            name = rd["name"].ToString(),
                            last_name = rd["last_name"].ToString(),
                            address = rd["address"].ToString(),
                            cellphone = Convert.ToInt32(rd["cellphone"]),
                            email = rd["email"].ToString(),
                            descripcion = rd["descripcion"].ToString(),
                            idNote = Convert.ToInt32(rd["idNote"])


                        });
                    }
                    return oStudent;
                }
            }
        }
        public static StudentModel GetStudent(int id)
        {
            StudentModel oStudent = new StudentModel();
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Select * from Students where id =@id", oConexion);
                cmd.Parameters.AddWithValue("@id", id);
                oConexion.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        oStudent = new StudentModel()
                        {
                            id = Convert.ToInt32(rd["id"]),
                            name = rd["name"].ToString(),
                            last_name = rd["last_name"].ToString(),
                            address = rd["address"].ToString(),
                            cellphone = Convert.ToInt32(rd["cellphone"]),
                            email = rd["email"].ToString(),
                            descripcion = rd["descripcion"].ToString(),
                            idNote = Convert.ToInt32(rd["idNote"])


                        };
                    }
                    return oStudent;
                }
            }
        }
    }
}

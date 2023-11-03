using Backend.Model;
using System.Data.SqlClient;

namespace Backend.Data
{
    public class TeacherData
    {
        public static bool Create(TeacherModel oTeacher)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Insert into Teachers(name,last_name,address,cellphone,email,descripcion) VALUES(@name,@last_name,@address,@cellphone,@email,@descripcion)",oConexion);
                cmd.Parameters.AddWithValue("@name", oTeacher.name);
                cmd.Parameters.AddWithValue("@last_name", oTeacher.last_name);
                cmd.Parameters.AddWithValue("@address", oTeacher.address);
                cmd.Parameters.AddWithValue("@cellphone", oTeacher.cellphone);
                cmd.Parameters.AddWithValue("@email", oTeacher.email);
                cmd.Parameters.AddWithValue("@descripcion", oTeacher.descripcion);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
        public static bool Update(TeacherModel oTeacher, int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Update Teachers Set name = @name ,last_name =@last_name, address =@address,cellphone =@cellphone,email=@email,descripcion=@descripcion WHERE id = @id", oConexion);
                cmd.Parameters.AddWithValue("@name", oTeacher.name);
                cmd.Parameters.AddWithValue("@last_name", oTeacher.last_name);
                cmd.Parameters.AddWithValue("@address", oTeacher.address);
                cmd.Parameters.AddWithValue("@cellphone", oTeacher.cellphone);
                cmd.Parameters.AddWithValue("@email", oTeacher.email);
                cmd.Parameters.AddWithValue("@descripcion", oTeacher.descripcion);
                cmd.Parameters.AddWithValue("@id", id);


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

        }
        public static bool Delete(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Delete from Teachers where id = @id", oConexion);
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

        public static List<TeacherModel> GetTeachers()
        {
            List<TeacherModel> oTeacher = new List<TeacherModel>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Select * from Teachers",oConexion);
                oConexion.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        oTeacher.Add(new TeacherModel()
                        {
                            id = Convert.ToInt32(rd["id"]),
                            name = rd["name"].ToString(),
                            last_name = rd["last_name"].ToString(),
                            address = rd["address"].ToString(),
                            cellphone = Convert.ToInt32(rd["cellphone"]),
                            email = rd["email"].ToString(),
                            descripcion = rd["descripcion"].ToString()


                        });
                    }
                    return oTeacher;
                }
            }
        }
        public static TeacherModel GetTeacher(int id)
        {
            TeacherModel oTeacher = new TeacherModel();
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Select * from Teachers where id =@id ",oConexion);
                cmd.Parameters.AddWithValue("@id", id);
                oConexion.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        oTeacher = new TeacherModel()
                        {
                            id = Convert.ToInt32(rd["id"]),
                            name = rd["name"].ToString(),
                            last_name = rd["last_name"].ToString(),
                            address = rd["address"].ToString(),
                            cellphone = Convert.ToInt32(rd["cellphone"]),
                            email = rd["email"].ToString(),
                            descripcion = rd["descripcion"].ToString()


                        };
                    }
                    return oTeacher;
                }
            }
        }
    }
}

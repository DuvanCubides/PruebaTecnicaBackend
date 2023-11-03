using Backend.Model;
using System.Data.SqlClient;

namespace Backend.Data
{
    public class CourseData
    {
        public static bool Create(CoursesModel oCourses)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Insert into Courses(nameCourse,idTeacher) VALUES(@nameCourse,@idTeacher)",oConexion);
                cmd.Parameters.AddWithValue("@nameCourse", oCourses.nameCourse);
                cmd.Parameters.AddWithValue("@idTeacher", oCourses.idTeacher);

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
        public static bool Update(CoursesModel oCourses, int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Update Courses Set nameCourse = @nameCourse ,idTeacher =@idTeacher WHERE id = @id", oConexion);
                cmd.Parameters.AddWithValue("@nameCourse", oCourses.nameCourse);
                cmd.Parameters.AddWithValue("@idTeacher", oCourses.idTeacher);
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
                SqlCommand cmd = new SqlCommand("Delete from Courses where id = @id",oConexion);
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public static List<CoursesModel> GetCourses()
        {
            List<CoursesModel> oCourses = new List<CoursesModel>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Select * from Courses", oConexion);
                oConexion.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        oCourses.Add(new CoursesModel()
                        {
                            id = Convert.ToInt32(rd["id"]),
                            nameCourse = rd["nameCourse"].ToString(),
                            idTeacher = Convert.ToInt32(rd["idTeacher"])


                        });
                    }
                    return oCourses;
                }
            }
        }
        public static CoursesModel GetCourse(int id)
        {
            CoursesModel oCourses = new CoursesModel();
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Select * from Notes where id =@id ",oConexion);
                cmd.Parameters.AddWithValue("@id", id);
                oConexion.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        oCourses = new CoursesModel()
                        {
                            id = Convert.ToInt32(rd["id"]),
                            nameCourse = rd["nameCourse"].ToString(),
                            idTeacher = Convert.ToInt32(rd["idTeacher"])
                        };
                    }
                    return oCourses;
                }
            }
        }
    }
}

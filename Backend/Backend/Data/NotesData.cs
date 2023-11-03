using Backend.Model;
using System.Data.SqlClient;

namespace Backend.Data
{
    public class NotesData
    {
        public static bool Create(NotesModel oNotes)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Insert into Notes(note,idCourse) VALUES(@Note,@idCourse)", oConexion);
                cmd.Parameters.AddWithValue("@Note", oNotes.Note);
                cmd.Parameters.AddWithValue("@idCourse", oNotes.idCourse);

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
        public static bool Update(NotesModel oNotes, int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Update Notes Set note = @note ,idCourse =@idCourse WHERE id = @id",oConexion);
                cmd.Parameters.AddWithValue("@Note", oNotes.Note);
                cmd.Parameters.AddWithValue("@idCourse", oNotes.idCourse);
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
                SqlCommand cmd = new SqlCommand("Delete from Notes where id = @id", oConexion);
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

        public static List<NotesModel> GetNotes()
        {
            List<NotesModel> oNotes = new List<NotesModel>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Select * from Notes",oConexion);
                oConexion.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        oNotes.Add(new NotesModel()
                        {
                            id = Convert.ToInt32(rd["id"]),
                            idCourse = Convert.ToInt32(rd["idCourse"]),
                            Note = Convert.ToDouble(rd["Note"])


                        });
                    }
                    return oNotes;
                }
            }
        }
        public static NotesModel GetNote(int id)
        {
            NotesModel oNotes = new NotesModel();
            using (SqlConnection oConexion = new SqlConnection(Conexion.sqlCon))
            {
                SqlCommand cmd = new SqlCommand("Select * from Notes where id =@id ", oConexion);
                cmd.Parameters.AddWithValue("@id", id);
                oConexion.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        oNotes = new NotesModel()
                        {
                            id = Convert.ToInt32(rd["id"]),
                            idCourse = Convert.ToInt32(rd["idCourse"]),
                            Note = Convert.ToDouble(rd["Note"])
                        };
                    }
                    return oNotes;
                }
            }
        }
    }
}

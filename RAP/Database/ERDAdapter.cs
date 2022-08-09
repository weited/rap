using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using RAP.Research;


namespace RAP.Database
{
    class ERDAdapter
    {

        private static bool reportingErrors = false;

        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;
        private static string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3};SslMode=none", db, server, user, pass);

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        //public ERDAdapter()
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            { 
            // Create connection object
            
            conn = new MySqlConnection(connectionString);
            }
            return conn;
        }


        //bacis researcher list
        public List<Researcher> fetchResearcherList()
        {
            List<Researcher> researchers = new List<Researcher>();
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                // Open the connection
                conn.Open();

               
                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title, type, level from researcher", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    
                    Researcher resList = new Researcher()
                    {
                        id = Int32.Parse(rdr.GetString(0)),
                        GivenName = rdr.GetString(1),
                        FamilyName = rdr.GetString(2),
                        Title = rdr.GetString(3),
                        Type = rdr.GetString(4)
                    };
                    if (rdr.IsDBNull(5)) resList.Level = "";
                    else resList.Level = rdr.GetString(5);

                    researchers.Add(resList);
                    
                   
                }
            }
             finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return researchers;
        }

        // Full researcher details
        public Researcher fetchResearcherDetails(int id)
        {
            Researcher detailResearcher = null;
            
            List<Publication> researchPublication = new List<Publication>();
            List<Position> researchPosition = new List<Position>();
            MySqlConnection conn = GetConnection();
            
            MySqlDataReader rdr = null;
            try
            {
                conn.Open();
                //Get Researcher Detail
                
                MySqlCommand cmd = new MySqlCommand("select id, type, given_name, family_name, title, unit, campus, email, photo, degree, supervisor_id, utas_start, current_start from researcher where id = ?id", conn);
                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();
                rdr.Read();

                if (rdr.GetString(1) == "Student")
                {
                    int selectedSuperVisorID = Int32.Parse(rdr.GetString(10));
                    detailResearcher = new Student()
                    {
                        id = Int32.Parse(rdr.GetString(0)),
                        GivenName = rdr.GetString(2),
                        FamilyName = rdr.GetString(3),
                        Title = rdr.GetString(4),
                        School = rdr.GetString(5),
                        Campus = rdr.GetString(6),
                        Email = rdr.GetString(7),
                        PhotoUrl = new Uri(rdr.GetString(8)),
                        Degree = rdr.GetString(9),
                        Supervisor = fetchSupervisor(selectedSuperVisorID),
                        UtasStart = rdr.GetDateTime(11),
                        CurrentStart = rdr.GetDateTime(12),
                    };
                }
                else
                {
                    detailResearcher = new Staff()
                    {
                        id = Int32.Parse(rdr.GetString(0)),
                        GivenName = rdr.GetString(2),
                        FamilyName = rdr.GetString(3),
                        Title = rdr.GetString(4),
                        School = rdr.GetString(5),
                        Campus = rdr.GetString(6),
                        Email = rdr.GetString(7),
                        PhotoUrl = new Uri(rdr.GetString(8)),
                        Supervisions = getSupervisorCount(Int32.Parse(rdr.GetString(0))),
                        UtasStart = rdr.GetDateTime(11),
                        CurrentStart = rdr.GetDateTime(12),
                    };
                }
                rdr.Close();

                //Get Publication for selected Researcher

                cmd = new MySqlCommand("select rp.doi, title, authors, year, type, cite_as, available from researcher_publication rp " + "LEFT JOIN publication p ON rp.doi = p.doi where researcher_id=?id order by year DESC, title ASC", conn);
                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    
                    researchPublication.Add(new Publication()
                    {
                        DOI = rdr.GetString(0),
                        Title = rdr.GetString(1),
                        Authors = rdr.GetString(2),
                        Year = rdr.GetString(3),
                        Type = ParseEnum<OutputType>(rdr.GetString(4)),
                        CiteAs = rdr.GetString(5),
                        Available = rdr.GetDateTime(6),
                        Age = DateTime.Now.Subtract(rdr.GetDateTime(6)).Days.ToString() + " Days"
                    });
                }
                rdr.Close();
                detailResearcher.publications = researchPublication;

                //Get Position for selected Researcher
                cmd = new MySqlCommand("select level, start, end from position where id =?id order by start DESC", conn);
                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {

                    while (rdr.Read())
                    {
                        Position resPostion = new Position()
               
                    {
                            Level = ParseEnum<EmploymentLevel>(rdr.GetString(0)), 
                            start = rdr.GetDateTime(1)
                    };

                     //Incase no dateTime 
                    if (!rdr.IsDBNull(2)) resPostion.end = rdr.GetDateTime(2);
                        researchPosition.Add(resPostion);
                    }
                }
                else
                {
                    Position resPosition = new Position()
                    {
                        Level = EmploymentLevel.Student
                    };
                    researchPosition.Add(resPosition);
                }
                rdr.Close();
                detailResearcher.positions = researchPosition;
            }
            catch (MySqlException e)
            {
                ReportError("Loading researcher details ", e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return detailResearcher;
        }

        private Researcher fetchSupervisor(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataReader rdr = null;
            Researcher studSupervisor = null;

            try 
            { 


                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand ("select id, given_name, family_name from researcher where id =?id", conn);
            
                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();
                rdr.Read();

                studSupervisor = new Researcher()
                {
                    id = Int32.Parse(rdr.GetString(0)),
                    GivenName = rdr.GetString (1),
                    FamilyName = rdr.GetString(2) 
                };
            }
            catch (MySqlException e)
            {
                ReportError("fetching Supervisor ", e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return studSupervisor;
        }


        private int getSupervisorCount(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataReader rdr = null;
            int count = 0;

            try
            {


                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select count(*) from researcher where supervisor_id =?id", conn);

                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                count = rdr.GetInt32(0);
               
            }
            catch (MySqlException e)
            {
                ReportError(" get SupervisorCount ", e);;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return count;
        }

        /*  add for button <show me> */
        public List<Researcher> fetchSupervisions(int id)
        {
            List<Researcher> researchers = new List<Researcher>();
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select given_name, family_name, title from researcher where supervisor_id=?id", conn);

                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Researcher selectedResearcher = new Researcher()
                    {
                        GivenName = rdr.GetString(0),
                        FamilyName = rdr.GetString(1),
                        Title = rdr.GetString(2)

                    };

                    researchers.Add(selectedResearcher);

                }

            }

            catch (MySqlException e)
            {
                ReportError("Loading Supervision ", e);
            }

            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }

            }
            return researchers;


        }


        private static void ReportError(string msg, Exception e)
        {
            if (reportingErrors)
            {
                MessageBox.Show("An error occurred while " + msg + ". Try again later.\n\nError Details:\n" + e,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




    }
}

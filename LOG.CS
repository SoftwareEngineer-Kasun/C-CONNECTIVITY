//STREAM READER
 using (FileStream Filetxt = File.OpenRead(x)) {               
                using (StreamReader Reader = new StreamReader(Filetxt))
                {
                    string line;
                    int i;
                    while ((line=Reader.ReadLine()) != null)
                    {
                        
                        
                    }
                    Reader.Close();
                    
//STREAM WRITER
using (System.IO.StreamWriter File = new System.IO.StreamWriter(Path))
            {
                foreach(string Item in list)
                {
                    File.WriteLine(Item); 
                    
                }
            }
//SQL CONNECTION
using (SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-GUUAU5K\SQLSERVER;Initial Catalog=ANDROIDBRAIN;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string Query = "INSERT INTO SECTORONE ([ID],[LOGICS]) VALUES (@ID,@LOGICS);";
                              
               
                foreach (string Data in list)
                {
                    Conn.Open();
                    using (SqlCommand DataQuery = new SqlCommand(Query))
                    {
                       
                        DataQuery.Connection = Conn;
                        DataQuery.Parameters.AddWithValue("@ID", x);
                        DataQuery.Parameters.AddWithValue("@LOGICS", Data); //EXECUTE QUERY
                        DataQuery.ExecuteNonQuery();
                        Conn.Close();
                    }
                    
//SQL READ DATA
using (SqlConnection Conn = new SqlConnection(ConnectionString))
                    {
                        Conn.Open();
                        using (SqlCommand StartSearch = new SqlCommand(Sub_Querry))
                        {
                            StartSearch.Connection = Conn;
                            using (SqlDataReader Reader = StartSearch.ExecuteReader(CommandBehavior.SequentialAccess))
                            {
                                
                                while (Reader.Read())
                                {
                                   Convert.ToInt32(Reader["ID"])
                                }
                                
                                Reader.Close();
                            }
                        }
                        Conn.Close();
